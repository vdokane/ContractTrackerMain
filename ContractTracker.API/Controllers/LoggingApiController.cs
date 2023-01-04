using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using ContractTracker.API.Services;
using ContractTracker.Common.ClientAndServerModels.Logging;
using ContractTracker.Services.Business.Factories;
using ContractTracker.Services.Business.Models.Logging;

namespace ContractTracker.API.Controllers
{
    [Route("api/logging")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LoggingApiController : BaseApiController
    {
        private readonly ISignedInUserService signedInUserServiceAccessor;
        public LoggingApiController(ISignedInUserService signedInUserServiceAccessor)
        {
            this.signedInUserServiceAccessor = signedInUserServiceAccessor;
        }

        [HttpPost("saveclienterror")]
        public async Task SaveClientError([FromBody] LoggingModel requestModel)
        {
            var currentUserName = signedInUserServiceAccessor.GetCurrentUserAccountName();

            var uowFactory = new UowFactory(GetConnectionString());
            var currentUserId = base.GetCurrentUserId();

            using (var uow = uowFactory.BuildUnitOfWork())
            {
                var businessServiceFactory = new BusinessServiceFactory(uow);
                var applicationErrorService = businessServiceFactory.BuildApplicationErrorService();

                var appErrorModel = new ApplicationErrorLogModel();
                appErrorModel.ErrorMessage = requestModel.Message;
                appErrorModel.CurrentPage = requestModel.CurrentPage;
                appErrorModel.CurrentUserId = currentUserId;
                appErrorModel.UserName = currentUserName;

                await applicationErrorService.SaveClientError(appErrorModel);

            }
        }
    }
}
