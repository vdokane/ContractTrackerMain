using ContractTracker.Services.Authentication.Authentication;
using ContractTracker.Services.Authentication.Interfaces;
using ContractTracker.Services.Authentication.Models;

namespace ContractTracker.Services.Authentication.Services
{
    public class AuthenticationService : ITrackerAuthenticationService
    {
        public AuthenticationService() { }
        public AuthenticationResponseModel VerifyUser(AuthenticationRequestModel request)
        {
            var response = new AuthenticationResponseModel();

            //If the user name contains the domain, remove it.
            if (request.UserName.Contains(@"/")) request.UserName = request.UserName.Replace(@"/", @"\\");
            if (!request.UserName.Contains(@"\\"))
            {
                string[] s = request.UserName.Split(Convert.ToChar(92));
                if (s.Length > 1)
                {
                    request.Domain = s[0].ToLower();
                    request.UserName = s[1];
                }
            }
            
            //TODO, in theory this should be an interface and injected via the factory.
            var activeDirectoryWorker = new ActiveDirectoryWorker(request.Domain, request.UserName, request.Password);
            var AdUser = activeDirectoryWorker.GetUser();

            if ((AdUser != null) && (AdUser.UserFound))
            {
                response.IsVerified = true;
            }

            return response;
        }
    }
}
