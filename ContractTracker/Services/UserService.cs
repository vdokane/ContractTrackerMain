using ContractTracker.Common.ClientAndServerRequestModels.UserModels;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ContractTracker.Services
{
    public interface IUserService
    {
        Task<UserResponseModel?> GetUserByUsername(string username);
    }
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserResponseModel?> GetUserByUsername(string username)
        {
            try
            {
                //TODO, better way of getting base URL
                var response = await httpClient.GetStringAsync("http://localhost:25940/api/user/getuserbyusername?username=" + username);

                if (string.IsNullOrEmpty(response))
                    return null;

                var userResponseModel = JsonConvert.DeserializeObject<UserResponseModel>(response);
                return userResponseModel;

                //var userResponseModel = new UserResponseModel();
                //return userResponseModel;
                /*
                var rawJson = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(rawJson))
                    return null;

                var userResponseModel = JsonConvert.DeserializeObject<UserResponseModel>(rawJson);
                return userResponseModel;
                */
            }
            catch(Exception ex)
            {
                string wtf = ex.ToString();
                return null;
            }
        }
    }
}
