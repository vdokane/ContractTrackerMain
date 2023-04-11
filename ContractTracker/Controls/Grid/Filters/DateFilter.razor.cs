using ContractTracker.ClientModels.Controls.Grid;
using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;

namespace ContractTracker.Controls.Grid.Filters
{
    public class DateFilterBase : ComponentBase
    {
        [Parameter]
        public EventCallback<GridDelegateModel> OnChangeCallback { get; set; }

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

        protected async Task ValueChanged(string newValue)
        {
            Console.WriteLine($"Date Filter, newValue: {newValue}");

            var gridDelegateModel = new GridDelegateModel();
            gridDelegateModel.FilterId = FilterId;
            gridDelegateModel.FilterValue = newValue;
            gridDelegateModel.EventType = "ValueChange"; //todo this needs to be an enum or something type safe to manage all the different event types a component filter can emit

            await OnChangeCallback.InvokeAsync(gridDelegateModel);
        }

        protected async Task RemoveMe()
        {
            Console.WriteLine("Date Filter RemoveMe clicked");
            var gridDelegateModel = new GridDelegateModel();
            gridDelegateModel.FilterId = FilterId;
            gridDelegateModel.EventType = "RemoveMe"; //todo this needs to be an enum or something type safe to manage all the different event types a component filter can emit

            await OnChangeCallback.InvokeAsync(gridDelegateModel);
        }
    }
}
