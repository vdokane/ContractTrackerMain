using Microsoft.AspNetCore.Components;
using ContractTracker.ClientModels;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.Vendor;
using ContractTracker.Controls.Grid;

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

        public void FilterStateChange(FilterModel model) //this needs to be an object with the property/filter name as well as value
        {
            Console.WriteLine($"From VendorSearch.razor, name: {model.FilterName}, value: {model.FilterValue}");
        }
    }
}
