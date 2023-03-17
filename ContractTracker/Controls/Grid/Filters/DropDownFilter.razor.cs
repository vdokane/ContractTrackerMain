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

        protected DropDownFilerComponent dropDownFilerComponent;

        public DropDownFilterBase()
        {

            dropDownFilerComponent = new DropDownFilerComponent();
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "one", Value = "1" });
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "two", Value = "2" });
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "three", Value = "3" });

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

       


    }

}

