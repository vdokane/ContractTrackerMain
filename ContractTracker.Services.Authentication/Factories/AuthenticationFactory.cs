using ContractTracker.Services.Authentication.Interfaces;
using ContractTracker.Services.Authentication.Services;

namespace ContractTracker.Services.Authentication.Factories
{
    public class AuthenticationFactory
    {
        public AuthenticationFactory()
        { }

        public ITrackerAuthenticationService BuildAuthenticatonService(bool useMock)
        {
            ITrackerAuthenticationService service;
            if (useMock)
                service = new AuthenticationMockService();
            else
                service = new AuthenticationService();
            return service;
        }

    }
}
