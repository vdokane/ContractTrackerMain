using Microsoft.AspNetCore.Mvc;
using ContractTracker.API.Services;

namespace ContractTracker.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build(); //Make sure to set 'copy always' on appsettings.json so it is in the Bin folder!

            var connectionString = config.GetConnectionString("ContractTrackerConnection");
            return connectionString;

        }
        protected int GetCurrentUserId()
        {
            var username = HttpContext.User?.Identity?.Name;
            //TODO builder.Services.AddScoped<IMyDependency, MyDependency>();
            IAuthenticatedUserService authenticatedUserService = new AuthenticatedUserService();  //THIS IS WRONG? SHOULD BE A BUSINESS SERVICE ..or..should it? 
            var userId = authenticatedUserService.GetCurrentUserId(username);
            return userId;
        }
        protected string GetCurrentUserName()
        {
            var username = HttpContext.User?.Identity?.Name;
            return (string.IsNullOrEmpty(username)) ? string.Empty : username; 
        }
    }
}
