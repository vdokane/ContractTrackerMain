using ContractTracker.ClientModels.Controls.Grid; //TODO delete
using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;
using ContractTracker.Infrastructure;

namespace ContractTracker.Controls.Grid.Filters
{
    public class StringFitlerBase : ComponentBase
    {

        [Parameter]
        public string FilterId { get; set; } = string.Empty;
        [Parameter]
        public string PlaceholderText { get; set; } = string.Empty;
        [Parameter]
        public string PreSetValue { get; set; }  = string.Empty;

        public StringFitlerBase()
        {

        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
