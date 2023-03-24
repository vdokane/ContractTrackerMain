using ContractTracker.ClientModels.Controls.Grid;
using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;

namespace ContractTracker.Controls.Grid.Filters
{
    public class DateFilterBase : ComponentBase
    {
        
        [Parameter]
        public string FilterId { get; set; } = string.Empty;
        
        [Parameter]
        public DateTime? PreSelectedValue { get; set; }  = null;
        public DateFilterBase()
        {
        
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
