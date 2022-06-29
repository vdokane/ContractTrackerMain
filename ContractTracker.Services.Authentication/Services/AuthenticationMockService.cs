using ContractTracker.Services.Authentication.Interfaces;
using ContractTracker.Services.Authentication.Models;

namespace ContractTracker.Services.Authentication.Services
{
    public class AuthenticationMockService : ITrackerAuthenticationService
    {
        private readonly List<FakeValidUsers> fakeValidUsers;
        public AuthenticationMockService()
        {
            fakeValidUsers = new List<FakeValidUsers>();
            fakeValidUsers.Add(new FakeValidUsers() { Domain = "flcourts", Username = "sally", WeakPassword = "word123" });
            fakeValidUsers.Add(new FakeValidUsers() { Domain = "flcourts", Username = "bob", WeakPassword = "321pass" });
            fakeValidUsers.Add(new FakeValidUsers() { Domain = "flcourts", Username = "ajay", WeakPassword = "345track" });
        }
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
            var user = fakeValidUsers.Where(x => x.Domain == request.Domain && x.Username == request.UserName && x.WeakPassword == request.Password).FirstOrDefault();
            if (user != null)
                response.IsVerified = true;
            else
                response.IsVerified = false;
            //TODO what else?
            return response;
        }

        private class FakeValidUsers
        {
            public string Domain { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public string WeakPassword { get; set; } = string.Empty;
        }
    }
}
