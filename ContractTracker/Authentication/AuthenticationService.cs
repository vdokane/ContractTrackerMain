using ContractTracker.Authentication.Models;
using ContractTracker.Infrastructure;
using System.Net.Http.Json;

namespace ContractTracker.Authentication
{
    internal interface IAuthenticationService
    {
        //Task<AuthorizedUserModel> Login(string userName, string passWord);
        Task<string?> LoginJwt(string domain, string userName, string passWord);
        void Logout();
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

        /// <summary>
        /// TODO- The base url and the URI should be a setting per environment.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        /*
        public async Task<AuthorizedUserModel> Login(string userName, string passWord)
        {

            var request = new AuthUserRequestModel() { Password = passWord, UserName = userName };
            var response = await httpClient.PostAsJsonAsync<AuthUserRequestModel>(baseUrlForApiSite + ServiceRoutes.LoginApiUrl, request);
            var jwt = await response.Content.ReadAsStringAsync();

            Common.Functionality.TokenBuilder tokenBuilder = new Common.Functionality.TokenBuilder();
            var claims = tokenBuilder.GetClaimsFromToken(jwt);
            AuthorizedUserModel currentUser = new AuthorizedUserModel();
            foreach (System.Security.Claims.Claim claim in claims)
            {
                if (claim.Type == "email")
                {
                    currentUser.Email = claim.Value;
                }
                else if (claim.Type == "role")
                {
                    currentUser.Role = claim.Value;
                }
                else if (claim.Type == "unique_name")
                {
                    currentUser.UserName = claim.Value;
                }
                else if (claim.Type == "nameid")
                {
                    currentUser.UserId = Convert.ToInt16(claim.Value);
                }
            }

            return currentUser;
            //todo, get the actual JWT from the response body        
            //await localStorageService.SetItemAsync("isUserValid", valid.Content);
            //await localStorageService.SetItemAsync("isUserValid", "todo"); (this might be better to do at the calling logic)
        }
        */

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

        public void Logout()
        {
            //Removed local storage
            //Notified auth state
            //Removed  _client.DefualtRequestHeaders.Authorization = null;
        }
    }
}
