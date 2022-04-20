using Microsoft.AspNetCore.Components;
using ContractTracker.ClientModels;
using System.Net.Http.Json;

namespace ContractTracker.Pages
{
    public class VendorSearchComponentBase : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected VendorModel[]? vendors;
        protected override async Task OnInitializedAsync()
        {
            vendors = await Http.GetFromJsonAsync<VendorModel[]>("sample-data/mockvendors.json");
            //TODO a universal debug flag
            Console.WriteLine(vendors);
        }
    }
}
