using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Security.Claims;

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
            var jwt = await localStorage.GetItemAsync<string>(localStorageKey);
            if (string.IsNullOrEmpty(jwt))
                return anonymous;

            var authUserToken = BuildAuthenticatedUserToken(jwt);
            return new AuthenticationState(authUserToken);
        }

        public void NotifyUserAuthenticaiton(string token)
        {
            var authenticatedUser = BuildAuthenticatedUserToken(token);
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
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
