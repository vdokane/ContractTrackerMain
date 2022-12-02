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
            var currentUserId = base.GetCurrentUser(); //todo, what works better? I would assume associating

            using (var uow = uowFactory.BuildUnitOfWork())
            {
                var businessServiceFactory = new BusinessServiceFactory(uow);
                var loggingService = businessServiceFactory.BuildLoggingService();

                var appErrorModel = new ApplicationErrorLogModel();
                appErrorModel.ErrorMessage = requestModel.Message;
                appErrorModel.CurrentPage = requestModel.CurrentPage;
                appErrorModel.CurrentUserName = currentUserName;

                await loggingService.SaveClientErrorLog(appErrorModel);

            }
        }
    }
}
