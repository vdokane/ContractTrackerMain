using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.QueryModels;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public interface IVendorQueryRepository
    {
        Task<List<VendorSearch_Result>> SearchVendors(VendorSearchRequestModel requestModel);
    }
    public class VendorQueryRepository : IVendorQueryRepository
    {
        private readonly TrackerDbContext context;
        public VendorQueryRepository(IUnitOfWork unitOfWork)
        {

            context = unitOfWork.GetContext();
        }

        public async Task<List<VendorSearch_Result>> SearchVendors(VendorSearchRequestModel requestModel)
        {

            var empRecord = await context.VendorSearch_Result
                .FromSqlRaw($"EXEC dbo.VendorSearch {requestModel.PageSize},{requestModel.PageNumber},'{requestModel.SortColumn}', '{requestModel.SortDirection}','{requestModel.FilterByVendorType}','{requestModel.FilterByVendorNumber}','{requestModel.FilterBySequenceNumber}','{requestModel.FilterByPurchasingName}'")
                .AsNoTracking()
                .ToListAsync();
            return empRecord;
            
            //return empRecord.ToList(); 
        }
    }
}
