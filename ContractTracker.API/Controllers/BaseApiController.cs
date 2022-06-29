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
        protected int GetCurrentUser()
        {
            var username = HttpContext.User?.Identity?.Name;
            //TODO builder.Services.AddScoped<IMyDependency, MyDependency>();
            IAuthenticatedUserService authenticatedUserService = new AuthenticatedUserService();  //THIS IS WRONG? SHOULD BE A BUSINESS SERVICE
            var userId = authenticatedUserService.GetCurrentUserId(username);
            return userId;
        }
    }
}
