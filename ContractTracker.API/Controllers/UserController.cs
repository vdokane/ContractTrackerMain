using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ContractTracker.Common.ClientAndServerModels.User;
using ContractTracker.Services.Business.Factories;

namespace ContractTracker.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : BaseApiController
    {
        //Cool! So I do get a 401! http://localhost:25940/api/login/GetUserIdByUserName?userName=okaned
        [HttpGet("getuseridbyusername")]
        public int GetUserIdByUserName(string userName)
        {
            //2022/05/31, we shouldn't really use this too much. This should be done per request. 
            var userId = base.GetCurrentUser();
            //TODO Here is where we would use the AUTHENTICATED username to find the user in this app's specifi database. This would build the actual user model which
            //   which would be app specific
            return userId;
        }


        [HttpGet("getuserbyusername")]
        public async Task<UserResponseModel?> GetUserByUserName(string username)
        {

            var uowFactory = new UowFactory(GetConnectionString());
            var currentUserId = base.GetCurrentUser(); //todo I don't think we need to verify who can get who

            using (var uow = uowFactory.BuildUnitOfWork())
            {
                var businessServiceFactory = new BusinessServiceFactory(uow);
                var userService = businessServiceFactory.BuidUserService(true); //TODO, build better way to use mocks at run time

                var userModel = await userService.GetUserByUserLoginName(username);
                //TODO, the role description should probably be included. userModel.UserRoleId
                if (userModel == null)
                    return null;

                return new UserResponseModel()
                {
                    Role = "GeneralServices",
                    UserId = userModel.UserId,
                    UserName = userModel.UserName,
                    UserUnitIds = userModel.UserUnitIds
                };
            }
        }
    }
}
