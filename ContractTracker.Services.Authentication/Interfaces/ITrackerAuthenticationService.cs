using ContractTracker.Services.Authentication.Models;

namespace ContractTracker.Services.Authentication.Interfaces
{
    public interface ITrackerAuthenticationService
    {
        AuthenticationResponseModel VerifyUser(AuthenticationRequestModel request);
    }
}
