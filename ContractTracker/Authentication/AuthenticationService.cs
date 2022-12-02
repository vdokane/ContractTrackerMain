using Blazored.LocalStorage;
using ContractTracker.Authentication.Models;
using ContractTracker.Common.Helpers;
using ContractTracker.Infrastructure;
using System.Net.Http.Json;

namespace ContractTracker.Authentication
{
    internal interface IAuthenticationService
    {
        //Task<AuthorizedUserModel> Login(string userName, string passWord);
        Task<string?> LoginJwt(string domain, string userName, string passWord);
        LocalStorageModel BuildLocalStorageModel(string jwtResponse);
    }
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly string baseUrlForApiSite;
        public AuthenticationService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            baseUrlForApiSite = configuration.GetValue<string>("BaseUrlApi");
        }

       

        public async Task<string?> LoginJwt(string domain, string userName, string passWord)
        {
            var request = new AuthUserRequestModel() { Password = passWord, UserName = userName, Domain=domain  };
            try
            {
                var route = baseUrlForApiSite + ServiceRoutes.LoginApiUrl;
                var response = await httpClient.PostAsJsonAsync<AuthUserRequestModel>(route, request);
                var jwt = await response.Content.ReadAsStringAsync();
                return jwt;
            }
            catch
            {
                return null;
            }
        }

        public LocalStorageModel BuildLocalStorageModel(string jwtResponse)
        {
            var localStorageModel = new LocalStorageModel();
            localStorageModel.cs9s9w2kcks = Base64Helper.Encode(DateTime.UtcNow.ToString());  //Encode for quick entropy
            localStorageModel.sdoj22sd0sld = jwtResponse;
            return localStorageModel;
        }
    }
}
