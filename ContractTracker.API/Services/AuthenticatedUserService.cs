namespace ContractTracker.API.Services
{
    //TODO, I already screwed up, this should be a BUSINESS SERVICE since the User will be in teh DB.
    public interface IAuthenticatedUserService
    {
        int GetCurrentUserId(string? userLoginName);
    }
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService() { }
        public int GetCurrentUserId(string? userLoginName)
        {
            //crap, I need like an API controller base to have access to this. GetCurrentUser would be a method in it
            //var username = HttpContext.User.Identity.Name;
            return 99;
        }
    }
}
