using Microsoft.AspNetCore.Components;
using ContractTracker.ClientModels;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.Vendor;

namespace ContractTracker.Pages
{
    public class VendorSearchComponentBase : ComponentBase
    {
        [Inject]
        IVendorService vendorService { get; set; } = null!;



        protected VendorModel[]? vendors;
        protected override async Task OnInitializedAsync()
        {
            decimal dBug = 1;
            var vendorsT = await vendorService.GetVendorById(1);


        }
    }
}
