using ContractTracker.ClientModels.Controls.Grid; //TODO delete
using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;
using ContractTracker.Infrastructure;

namespace ContractTracker.Controls.Grid.Filters
{
    public class StringFitlerBase : ComponentBase
    {

        [Parameter]
        public EventCallback<GridDelegateModel> OnChangeCallback { get; set; }

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

        protected async Task ValueChanged(string newValue)
        {
            Console.WriteLine($"String Filter, newValue: {newValue}");

            var gridDelegateModel = new GridDelegateModel();
            gridDelegateModel.FilterId = FilterId;
            gridDelegateModel.FilterValue = newValue;
            gridDelegateModel.EventType = "ValueChange"; //todo this needs to be an enum or something type safe to manage all the different event types a component filter can emit

            await OnChangeCallback.InvokeAsync(gridDelegateModel);
        }

        protected async Task RemoveMe()
        {
            Console.WriteLine("String Filter RemoveMe clicked");
            var gridDelegateModel = new GridDelegateModel();
            gridDelegateModel.FilterId = FilterId;
            gridDelegateModel.EventType = "RemoveMe"; //todo this needs to be an enum or something type safe to manage all the different event types a component filter can emit

            await OnChangeCallback.InvokeAsync(gridDelegateModel);
        }
    }
}
