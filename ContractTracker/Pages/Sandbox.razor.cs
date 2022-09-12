using Microsoft.AspNetCore.Components;
using ContractTracker.Authentication;
using ContractTracker.ClientModels.LoginModels;
using ContractTracker.ClientModels.Generic;
using Radzen;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.User;
using ContractTracker.Common.ClientAndServerModels.Exception;

namespace ContractTracker.Pages
{
    public class SandboxComponentBase : ComponentBase
    {
        [Inject]
        public ISandboxService sandboxService { get; set; } = null!;


        [Inject]
        public NotificationService NotificationService { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected async Task GetComplexModel()
        {
            decimal dBug = -1;
            var model = await sandboxService.GetUserResponseModelNoParams();

        }

        protected async Task GetComplexModelWithParams()
        {
            decimal dBug = -1;
            var responseModel = await sandboxService.GetComplexModelWithParams(7832, "UserNanme From Component");
            HandleResponseNotification(responseModel);
        }

        protected async Task PostObject()
        {
            var requestModel = new UserInsertRequestModel() { UserRoleId = 22, UserName = "fromComponent", UnitId = 44, FirstName = "fnmae", LastName = "lname", StartDate = DateTime.Now };
            var responseModel = await sandboxService.PostExample(requestModel);
            HandleResponseNotification(responseModel);
        }

        protected async Task InvokeKaboom()
        {
            //So how do I capture the response? And tell the difference between a regular exception and a business rule exception?
            var responseModel = await sandboxService.InvokeKaboom();
        }

        protected async Task InvokeBusinessRuleKaboom()
        {
            //by keeping the try catch at the service level this will bind all response models to know what a business error is
            //ok, so having it as a base class works dandy, so now every service method should just check the flag and push it back to the UI if errors
            var responseModel = await sandboxService.InvokeBusinessRuleKaboom();

            //TODO all components should be able to handle this the same
            HandleResponseNotification(responseModel);

        }

        private void HandleResponseNotification(BaseResponseModel baseResponse)
        {
            if (baseResponse == null)
                return; //TODO actually this should be a generic error message or somethign like"your request could not be processed at this time

            var notificationMessage = new NotificationMessage();
            notificationMessage.Duration = 40000;
            //notificationMessage.Style = "position: absolute; left: -1000px;"; TODO

            if (baseResponse.IsBusinessException)
            {

                notificationMessage.Severity = NotificationSeverity.Error;
                notificationMessage.Summary = "FAIL Summary";
                notificationMessage.Detail = "FAIL Detail";

            }
            else
            {
                notificationMessage.Severity = NotificationSeverity.Success;
                notificationMessage.Summary = "PASS Summary";
                notificationMessage.Detail = "PASS Detail";

            }
            NotificationService.Notify(notificationMessage);
        }

    }


}
