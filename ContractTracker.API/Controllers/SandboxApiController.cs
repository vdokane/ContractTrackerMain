using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ContractTracker.Common.ClientAndServerModels.User;
using ContractTracker.Services.Business.Factories;
using ContractTracker.API.Services;
using ContractTracker.Common.Infrastructure;

namespace ContractTracker.API.Controllers
{
    [Route("api/sandbox")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SandboxApiController : BaseApiController
    {
        //builder.Services.AddHttpContextAccessor();
        private readonly ISignedInUserService signedInUserServiceAccessor; //todo, inject
        public SandboxApiController(ISignedInUserService signedInUserServiceAccessor)
        {
            this.signedInUserServiceAccessor = signedInUserServiceAccessor;
            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-context?view=aspnetcore-6.0 
            //crap Don't capture IHttpContextAccessor.HttpContext in a constructor.
            //signedInUserServiceAccessor = new SignedInUserService(HttpContextAccessor); //??So what do you inject? 
            //TODO https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/dependency-injection
        }


        [HttpGet("getnow")]
        public DateTime GetNow()
        {
            var now = DateTime.UtcNow;
            return now;
        }

        [HttpGet("getcomplexmodel")]
        public UserResponseModel GetComplexModel()
        {
            decimal dBug = -1;
            return new UserResponseModel() { Role = "sandbox", UserId=999, UserName="Demo Sandbox", UserUnitIds = new List<int>() { 1, 2, 34 } };
        }

        [HttpGet("getcomplexmodelwithparams")]
        public UserResponseModel GetComplexModelWithParams(int userId, string userName)
        {
            decimal dBug = -1;
            return new UserResponseModel() { Role = "sandbox", UserId = userId, UserName = userName, UserUnitIds = new List<int>() { 1, 2, 34 } };
        }

        [HttpPost("insertuser")]
        public UserResponseModel CreateUser([FromBody]UserInsertRequestModel requestModel)
        {
            decimal dBug = -1;
            var currentUserName = ThisShouldBeaService_GetCurrentUserAccountName();
            //var signedInUserService = new SignedInUserService(HttpContext); //So this works, but how do I avoid calling this on EVERY api method? 
            //var shouldAlsoBeCurrentUserName = signedInUserService.GetCurrentUserAccountName();
            
            
            
            
            
            //Oh shit it worked!!
            var shouldBeCurrentUserName3 = signedInUserServiceAccessor.GetCurrentUserAccountName();


            var mutatedData = requestModel.UnitId + 1;
             return new UserResponseModel() { Role = "sandbox", UserId = 777, UserName = requestModel.UserName, UserUnitIds = new List<int>() { mutatedData } };

        }

        [HttpPost("insertuserauthorized")]
        public UserResponseModel CreateUserAuthorized([FromBody] UserInsertRequestModel requestModel)
        {
            decimal dBug = -1;
            var currentUserName = ThisShouldBeaService_GetCurrentUserAccountName();
            //var shouldAlsoBeCurrentUserName = signedInUserService.GetCurrentUserAccountName();
            //TODO, then use currentUserName to make sure they have the permissions to do stuff
            var mutatedData = requestModel.UnitId + 1;
            return new UserResponseModel() { Role = "sandbox", UserId = 777, UserName = requestModel.UserName, UserUnitIds = new List<int>() { mutatedData } };

        }

        [HttpPost("kaboom")]
        public UserResponseModel Kaboom()
        {
            decimal dBug = -1;
            var ValidationMessages = new ValidationMessage[] { new ValidationMessage("99", "messag1"), new ValidationMessage("98", "message2") };
            throw new BusinessRuleException(ValidationMessages); //So why didn't my messages get send with error?
            //throw new Exception("Kaboom");

            return new UserResponseModel() { Role = "sandbox", UserId = 777, UserName = "Kaboom.User", UserUnitIds = new List<int>() { 1,2,3 } };

        }



        private string? ThisShouldBeaService_GetCurrentUserAccountName()
        {
            //var tst1 = HttpContext.User;
            //var tst = HttpContext.User.Identity.IsAuthenticated;
            

            if (HttpContext.User == null)
                return null;
            
            var shouldBeName = HttpContext.User.Identity.Name;
            return shouldBeName;

        }

    }
}
