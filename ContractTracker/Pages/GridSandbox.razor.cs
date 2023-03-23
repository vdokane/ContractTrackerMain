using Microsoft.AspNetCore.Components;
using ContractTracker.ClientModels;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.Vendor;
using ContractTracker.Controls.Grid;
using ContractTracker.ClientModels.Generic;

namespace ContractTracker.Pages
{
    public class AllSearchFilterComponent
    {
        public List<SelectComponetModel> HardCodedSelectOptions = new List<SelectComponetModel>();
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

    }
    public class GridSandboxComponentBase : ComponentBase
    {
        protected readonly AllSearchFilterComponent allSearchFilterComponent;
        public Type? filterComponentType;
        public string TextToTest { get; set; } = string.Empty;

        public List<DynamicComponent> AllFilterComponents { get; set; } = new List<DynamicComponent>();

        public GridSandboxComponentBase()
        {
            allSearchFilterComponent = new AllSearchFilterComponent();
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by Input 1", Value = "filterByInput1" });
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by DateTime", Value = "filterByDateTime" });
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by Input 2", Value = "filterByInput2" });
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by Drop Down", Value = "filterBySelect" });
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected void FitlerValueChanged(string newValue)
        {
            Console.WriteLine(newValue);
            allSearchFilterComponent.Value = newValue;

        }

        protected void HandleValidSubmit()
        {
            Console.WriteLine("HandleValidSubmit called", allSearchFilterComponent.Value);

            TextToTest += allSearchFilterComponent.Value;
            //... now, how to add components here.. shit..
            //https://learn.microsoft.com/en-us/aspnet/core/blazor/components/dynamiccomponent?view=aspnetcore-6.0
            //https://www.youtube.com/watch?v=6JIADmG2kxo
            //So how can I appened? 

            //TODO
            //The values from HardCodedSelectOptions should be mapped back to a list of objects, the component name should be determined by the value of, well, the value

            //var mappedName
            //filterComponentType = e.Value?.ToString()?.Length > 0 ?
            if (allSearchFilterComponent.Value == "filterByInput1")
            {
                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterByInput1");
                if(option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);
                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.StringFilter");

                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;
                var paramsForCompnt = new Dictionary<string, object>();
                dynamicComponent.Parameters = paramsForCompnt;
                AllFilterComponents.Add(dynamicComponent);

            }
            else if (allSearchFilterComponent.Value == "filterByDateTime")
            {
                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterByDateTime");
                if (option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);

                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.DateFilter");

                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;
                var paramsForCompnt = new Dictionary<string, object>();
                dynamicComponent.Parameters = paramsForCompnt;
                AllFilterComponents.Add(dynamicComponent);

            }
            else if (allSearchFilterComponent.Value == "filterByInput2")
            {
                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterByInput2");
                if (option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);

                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.StringFilter");

                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;
                var paramsForCompnt = new Dictionary<string, object>();
                dynamicComponent.Parameters = paramsForCompnt;
                AllFilterComponents.Add(dynamicComponent);

            }
            else if (allSearchFilterComponent.Value == "filterBySelect")
            {
                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterBySelect");
                if (option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);

                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.DropDownFilter");

                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;
                var paramsForCompnt = new Dictionary<string, object>();
                dynamicComponent.Parameters = paramsForCompnt;
                AllFilterComponents.Add(dynamicComponent);

            }
            else
                filterComponentType = null;
        }
    }
}
