using Blazored.LocalStorage;
using ContractTracker.Authentication;
using ContractTracker.Common.ClientAndServerModels.Vendor;
using ContractTracker.Infrastructure;
using Newtonsoft.Json;

namespace ContractTracker.Services
{
    public interface IVendorService
    {
        Task<VendorResponseModel?> GetVendorById(int vendorId);
    }
    public class VendorService : ServiceBase, IVendorService
    {
        public VendorService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage) : base(httpClient, configuration, localStorage)
        {

        }

        public async Task<VendorResponseModel?> GetVendorById(int vendorId)
        {
            try
            {
                await SetJwtAuthHeader();

                var route = baseUrlForApiSite + ServiceRoutes.Vendor.GetVendorByIdApiUrl(vendorId);
                var response = await httpClient.GetStringAsync(route);

                if (string.IsNullOrEmpty(response))
                    return null;

                var responseModel = JsonConvert.DeserializeObject<VendorResponseModel>(response);
                return responseModel;
            }
            catch (Exception ex)
            {
                string wtf = ex.ToString();
                return null;
            }
        }
    }
}
