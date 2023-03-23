using ContractTracker.ClientModels.Controls.Grid;
using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;
using ContractTracker.Infrastructure;

namespace ContractTracker.Controls.Grid.Filters
{
    public class StringFitlerBase : ComponentBase
    {

        [Parameter]
        public IDictionary<string, object> FitlerParameters { get; set; } //Can this be type safe
        protected readonly StringFilterParameterModel stringFilterParameterModel;
        public StringFitlerBase()
        {
            if (FitlerParameters == null)
                FitlerParameters = new Dictionary<string, object>();
            
            stringFilterParameterModel = FitlerParameters.ToObject<StringFilterParameterModel>();
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
