using ContractTracker.Services.Business.Models.Vendor;
using ContractTracker.Repository.QueryRepositories;
using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Services.Business.Services
{
    public interface IVendorService
    {
        Task<VendorSearchResponseModel> SearchVendors(VendorSearchRequestModel request);
    }
    public class VendorService : IVendorService
    {
        private readonly IVendorQueryRepository vendorQueryRepository;
        public VendorService(IVendorQueryRepository vendorQueryRepository)
        {
            this.vendorQueryRepository = vendorQueryRepository;
        }

        public async Task<VendorSearchResponseModel> SearchVendors(VendorSearchRequestModel request)
        {
            var response = new VendorSearchResponseModel();
            var searchParameters = new Repository.QueryModels.VendorSearchRequestModel();
            searchParameters.FilterByVendorNumber = request.FilterByVendorNumber;
            searchParameters.FilterBySequenceNumber = request.FilterBySequenceNumber;
            searchParameters.FilterByPurchasingName = request.FilterByPurchasingName;
            //TOOD, need a generic way of mapping these for all search/grid based requests
            searchParameters.PageNumber = request.PageNumber;
            searchParameters.PageSize = request.PageSize;
            searchParameters.SortDirection = request.SortDirection;
            searchParameters.SortColumn = request.SortColumn;

            var results = await vendorQueryRepository.SearchVendors(searchParameters);

            response.CurrentPageNumber = request.PageNumber;
            response.TotalRows = results.Count() > 0 ? results.First().MaxRows : 0;
            response.SearchResults = results.ConvertAll(MapResultToSearchResult);
            return response;
        }

        private VendorSearchDataModel MapResultToSearchResult(VendorSearch_Result record)
        {
            var model = new VendorSearchDataModel();
            model.VendorNumber = record.VendorNumber;
            model.SequenceNumber = record.SequenceNumber;
            model.VendorId = record.VendorId;
            model.PurchasingNameLine1 = record.PurchasingNameLine1;
            model.StatusCode = record.StatusCode;
            model.VendorType = record.VendorType;
            return model;
        }
    }
}
