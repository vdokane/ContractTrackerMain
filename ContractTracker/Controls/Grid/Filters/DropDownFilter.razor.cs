using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;

namespace ContractTracker.Controls.Grid.Filters
{
    public class DropDownFilerComponent
    {
        public List<SelectComponetModel> HardCodedSelectOptions = new List<SelectComponetModel>();
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public class DropDownFilterBase : ComponentBase
    {
        [Parameter]
        public EventCallback<FilterModel> OnChangeCallback { get; set; }

        [Parameter]
        public string NameOfThisFilter { get; set; }


        protected DropDownFilerComponent dropDownFilerComponent;

        public DropDownFilterBase()
        {

            dropDownFilerComponent = new DropDownFilerComponent();
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "one", Value = "1" });
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "two", Value = "2" });
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "three", Value = "3" });

            NameOfThisFilter = "fromConstructor";

        }

        protected override async Task OnInitializedAsync()
        {
            dropDownFilerComponent.Value = "two";
            await base.OnInitializedAsync();
        }

        protected async Task ValueChanged(string newValue)
        {
            Console.WriteLine(newValue);
            dropDownFilerComponent.Value = newValue;
            var filterModel = new FilterModel();
            filterModel.FilterName = NameOfThisFilter;
            filterModel.FilterValue = newValue;
            await OnChangeCallback.InvokeAsync(filterModel);
            //return Task.CompletedTask;
        }




    }

}

