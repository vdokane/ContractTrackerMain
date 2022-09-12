using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Security.Claims;
using ContractTracker.Authentication.Models;
using ContractTracker.Common.Helpers;

namespace ContractTracker.Authentication
{
    public class TrackerAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IConfiguration config;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationState anonymous;

        public TrackerAuthenticationStateProvider(ILocalStorageService localStorage, IConfiguration config)
        {
            this.localStorage = localStorage;
            this.config = config;
            var identity = new ClaimsIdentity();
            var notFound = new ClaimsPrincipal(identity);
            anonymous = new AuthenticationState(notFound);
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var authConstants = new AuthConstants(config);
            var localStorageKey = authConstants.LocalStorageKeyForJwt;

            var localStorageModel = await localStorage.GetItemAsync<LocalStorageModel>(localStorageKey);
            if (localStorageModel == null)
                return anonymous;


            //Since local storage does not expire, get the last login time. If the user hasn't logged in during the past 24 hours, force a logout. 
            var decodedLastLoginTime = Base64Helper.Decode(localStorageModel.cs9s9w2kcks);
            var now = DateTime.UtcNow;
            DateTime dateResult;
            DateTime.TryParse(decodedLastLoginTime, out dateResult);
            var ts = now.Subtract(dateResult);
            if (ts.TotalHours > 24)
            {
                await NotifyUserLogout();
            }

            var authUserToken = BuildAuthenticatedUserToken(localStorageModel.sdoj22sd0sld);
            return new AuthenticationState(authUserToken);
        }

        public void NotifyUserAuthenticaiton(string token)
        {
            var authenticatedUser = BuildAuthenticatedUserToken(token);
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            //Note, this must be added first so the API's that validate the user can have authentication.
            //but how will this apply it ato all
            //Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


            NotifyAuthenticationStateChanged(authState);
        }

        public async Task NotifyUserLogout()
        {
            var authConstants = new AuthConstants(config);
            var localStorageKey = authConstants.LocalStorageKeyForJwt;
            await localStorage.RemoveItemAsync(localStorageKey);
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }

        #region private methods
        /*
        private ClaimsPrincipal BuildAuthenticatedUser(AuthorizedUserModel authorizedUserModel)
        {
            var claimsIdentity = new ClaimsIdentity(null, "Basic");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, authorizedUserModel.Email));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, authorizedUserModel.Role));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, authorizedUserModel.UserName));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, authorizedUserModel.UserId.ToString()));

            var authenticatedUser = new ClaimsPrincipal(claimsIdentity);
            return authenticatedUser;
        }
        */
        private ClaimsPrincipal BuildAuthenticatedUserToken(string token)
        {

            var tokenBuilder = new Common.Functionality.TokenBuilder();
            var claims = tokenBuilder.GetClaimsFromToken(token);

            var claimsIdentity = new ClaimsIdentity(null, "Basic");

            //Or use LINQ here.. WE ARE ALSO DOING THIS MAPPING IN AuthenticatinService ..this needs to be in once place
            foreach (System.Security.Claims.Claim claim in claims)
            {
                if (claim.Type == "email")
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, claim.Value));
                }
                else if (claim.Type == "role")
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, claim.Value));
                }
                else if (claim.Type == "unique_name")
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, claim.Value));
                }
                else if (claim.Type == "nameid")
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, claim.Value));
                }
            }

            var authenticatedUser = new ClaimsPrincipal(claimsIdentity);
            return authenticatedUser;
        }
        #endregion
    }
}
