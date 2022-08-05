using ContractTracker.Common.ClientAndServerModels.User;
using Newtonsoft.Json;
using ContractTracker.Infrastructure;
using ContractTracker.Authentication;
using Blazored.LocalStorage;

namespace ContractTracker.Services
{
    public interface IUserService
    {
        Task<UserResponseModel?> GetUserByUsername(string username);
    }
    public class UserService : ServiceBase, IUserService
    {
        public UserService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage) : base(httpClient, configuration, localStorage)
        {
        }

        public async Task<UserResponseModel?> GetUserByUsername(string username)
        {
            try
            {
                await SetJwtAuthHeader();
                var route = baseUrlForApiSite + ServiceRoutes.User.GetUserByUsernameApiUrl(username);
                var response = await base.httpClient.GetStringAsync(route);

                if (string.IsNullOrEmpty(response))
                    return null;

                var responseModel = JsonConvert.DeserializeObject<UserResponseModel>(response);
                return responseModel;
            }
            catch  
            {
                return null;
            }
        }
    }
}
