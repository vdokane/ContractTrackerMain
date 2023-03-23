using ContractTracker.ClientModels.Controls.Grid;
using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;

namespace ContractTracker.Controls.Grid.Filters
{
    public class DateFilterBase : ComponentBase
    {
        protected readonly DateTimeFilterParameterModel ComponentModel;
        [Parameter]
        public IDictionary<string, object> FitlerParameters { get; set; } //Can this be type safe
        public DateFilterBase()
        {
            if (FitlerParameters == null)
                FitlerParameters = new Dictionary<string, object>();

            ComponentModel = new DateTimeFilterParameterModel();
            //TODO map from FilterParams back to model using reflection
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
