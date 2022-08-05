using Microsoft.AspNetCore.Components;
using ContractTracker.Authentication;
using ContractTracker.ClientModels.LoginModels;
using ContractTracker.ClientModels.Generic;
using Radzen;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.User;

namespace ContractTracker.Pages
{
    public class SandboxComponentBase : ComponentBase
    {
        [Inject]
        public ISandboxService sandboxService { get; set; } = null!;
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
            var model = await sandboxService.GetComplexModelWithParams(7832,"UserNanme From Component");
        }

        protected async Task PostObject()
        {
            var requestModel = new UserInsertRequestModel() { UserRoleId = 22, UserName = "fromComponent", UnitId = 44, FirstName = "fnmae", LastName = "lname", StartDate = DateTime.Now };
            var responseModel = await sandboxService.PostExample(requestModel);
        }

        protected async Task InvokeKaboom()
        {
            //So how do I capture the response? And tell the difference between a regular exception and a business rule exception?
            var responseModel = await sandboxService.InvokeKaboom();
        }
        
    }


}
