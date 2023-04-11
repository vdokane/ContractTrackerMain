using Microsoft.AspNetCore.Components;
using ContractTracker.ClientModels;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.Vendor;
using ContractTracker.Controls.Grid;
using ContractTracker.ClientModels.Generic;
using ContractTracker.ClientModels.Controls.Grid;
using ContractTracker.Infrastructure;
using System.Reflection;
using Microsoft.AspNetCore.Components.Web;

namespace ContractTracker.Pages
{
    public class AllSearchFilterComponent
    {
        public List<SelectComponetModel> HardCodedSelectOptions = new List<SelectComponetModel>();
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

    }

    public class GridSandboxSearchRequestApiModel
    {
        public string FilterByInput1 { get; set; } = string.Empty;
        public string FilterByInput2 { get; set; } = string.Empty;
        public string FilterByDateTime { get; set; } = string.Empty;
        public string FilterBySelect { get; set; } = string.Empty;
        public string PageSize { get; set; } = string.Empty;
        public string PageNumber { get; set; } = string.Empty;
    }


    public class GridSandboxComponentBase : ComponentBase
    {
        protected readonly AllSearchFilterComponent allSearchFilterComponent;
        public Type? filterComponentType;
        public string TextToTest { get; set; } = string.Empty;
        public GridSandboxSearchRequestApiModel gridSandboxSearchRequestApiModel { get; set; }
        public List<DynamicComponent> AllFilterComponents { get; set; } = new List<DynamicComponent>();

        public GridSandboxComponentBase()
        {
            allSearchFilterComponent = new AllSearchFilterComponent();
            
            LoadOptions();

        }
        protected override async Task OnInitializedAsync()
        {
            gridSandboxSearchRequestApiModel = new GridSandboxSearchRequestApiModel();
            await base.OnInitializedAsync();
        }

        protected void FitlerValueChanged(string newValue)
        {
            Console.WriteLine(newValue);
            allSearchFilterComponent.Value = newValue;

        }

        protected void RemoveAllFilters(MouseEventArgs e)
        {
            //TODO, so how do I remove just one via an event!? :( 
            Console.WriteLine("RemoveAllFilters called");
            AllFilterComponents.Clear();
            allSearchFilterComponent.HardCodedSelectOptions.Clear();
            LoadOptions();

        }

        protected void HandleValidSubmit()
        {
            Console.WriteLine("--===========================================================--");
            Console.WriteLine("so what is the bug, last record is holding onto last value?");
            Console.WriteLine("HandleValidSubmit called, allSearchFilterComponent.Value:");
            Console.WriteLine(allSearchFilterComponent.Value);
            Console.WriteLine("^^^^^^");


            if (string.IsNullOrEmpty(allSearchFilterComponent.Value))
                return;

            //... now, how to add components here.. shit..
            //https://learn.microsoft.com/en-us/aspnet/core/blazor/components/dynamiccomponent?view=aspnetcore-6.0
            //https://www.youtube.com/watch?v=6JIADmG2kxo
            //So how can I appened? 

            //TODO
            //TODO!!! SHOULD I BE USING: ComponentMetadata private Dictionary<string, ComponentMetadata> components =            new() https://learn.microsoft.com/en-us/aspnet/core/blazor/components/dynamiccomponent?view=aspnetcore-7.0
            //The values from HardCodedSelectOptions should be mapped back to a list of objects, the component name should be determined by the value of, well, the value

            //var mappedName
            //filterComponentType = e.Value?.ToString()?.Length > 0 ?
            if (allSearchFilterComponent.Value == "filterByInput1")
            {

                Console.WriteLine("filterByInput1 selected");

                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterByInput1");
                if (option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);


                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.StringFilter");

                var stringFilterParameterModel = new StringFilterParameterModel();
                stringFilterParameterModel.FilterId = "filterByInput1";
                stringFilterParameterModel.PreSetValue = "this comes from GridSandbox1";
                stringFilterParameterModel.PlaceholderText = "Place holder text1";
                var paramsForCompnt = stringFilterParameterModel.AsDictionary();

                Console.WriteLine(paramsForCompnt.ToArray());

                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;

                dynamicComponent.Parameters = paramsForCompnt;
                //TODO, check to make sure it doesn't already exist... but how?!
                Console.WriteLine(dynamicComponent);
                AllFilterComponents.Add(dynamicComponent);

            }
            else if (allSearchFilterComponent.Value == "filterByDateTime")
            {
                Console.WriteLine("filterByDateTime selected");

                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterByDateTime");
                if (option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);

                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.DateFilter");

                //TODO, it would be nice to make a component model after all so this could be type safe
                var paramsForCompnt = new Dictionary<string, object>();
                paramsForCompnt.Add("FilterId", "filterByDateTime"); //should this be ComponentMetadata??? From link liek MS says
                paramsForCompnt.Add("PreSelectedValue", System.DateTime.Now);
                paramsForCompnt.Add("OnChangeCallback", EventCallback.Factory.Create<GridDelegateModel>(this, FilterStateChange));

                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;

                dynamicComponent.Parameters = paramsForCompnt;
                AllFilterComponents.Add(dynamicComponent);

            }
            else if (allSearchFilterComponent.Value == "filterByInput2")
            {

                Console.WriteLine("filterByInput2 selected");
                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterByInput2");
                if (option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);

                //This seems silly to flatten out an object to a dictionary and then rebuild it back in the DynamicControl, but I guess
                //that was MS's way of making it consistent and re-usable


                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.StringFilter");
                var stringFilterParameterModel = new StringFilterParameterModel();
                stringFilterParameterModel.FilterId = "filterByInput2";
                stringFilterParameterModel.PreSetValue = "this comes from GridSandbox2";
                stringFilterParameterModel.PlaceholderText = "Place holder text2";



                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;
                var paramsForCompnt = stringFilterParameterModel.AsDictionary();
                dynamicComponent.Parameters = paramsForCompnt;
                AllFilterComponents.Add(dynamicComponent);

            }
            else if (allSearchFilterComponent.Value == "filterBySelect")
            {

                Console.WriteLine("filterBySelect selected");

                var option = allSearchFilterComponent.HardCodedSelectOptions.Find(x => x.Value == "filterBySelect");
                if (option != null)
                    allSearchFilterComponent.HardCodedSelectOptions.Remove(option);

                filterComponentType = Type.GetType($"ContractTracker.Controls.Grid.Filters.DropDownFilter");
                if (filterComponentType == null)
                    return;

                var paramsForCompnt = new Dictionary<string, object>();
                paramsForCompnt.Add("FilterId", "filterBySelect"); //should this be ComponentMetadata??? From link liek MS says
                paramsForCompnt.Add("PreSelectedValue", "filterByInput2");
                paramsForCompnt.Add("OnChangeCallback", EventCallback.Factory.Create<GridDelegateModel>(this, FilterStateChange));



                var dynamicComponent = new DynamicComponent();
                dynamicComponent.Type = filterComponentType;
                dynamicComponent.Parameters = paramsForCompnt;

                AllFilterComponents.Add(dynamicComponent);







            }
            //else
            //   filterComponentType = null;

            //force the select to have another value selceted
            var tst = allSearchFilterComponent.HardCodedSelectOptions.FirstOrDefault();
            if (tst != null)
                allSearchFilterComponent.Value = tst.Value;
        }

        public void FilterStateChange(GridDelegateModel model) 
        {
            Console.WriteLine($"From GridSanbox.razor.cs, FilterId: {model.FilterId}, FilterValue: {model.FilterValue}, EventTYpe:  {model.EventType}");

            if (model.EventType == "ValueChange")
            {
                PropertyInfo? propertyInfo = gridSandboxSearchRequestApiModel.GetType().GetProperty(model.FilterId, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                    propertyInfo.SetValue(gridSandboxSearchRequestApiModel, model.FilterValue);

                Console.WriteLine($"Did it work? {gridSandboxSearchRequestApiModel.FilterBySelect}");

                //TODO, call the service to issue a new search request, refresh the grid! 
            }
            else if (model.EventType == "RemoveMe")
            {
                Console.WriteLine("the filter has removed itself, add it back to the available lists");
            }
            //Ignore all other delegate event types for now
        }

        private void LoadOptions()
        {
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "-- Select -- ", Value = string.Empty });
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by Input 1", Value = "filterByInput1" });
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by DateTime", Value = "filterByDateTime" });
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by Input 2", Value = "filterByInput2" });
            allSearchFilterComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "Filter by Drop Down", Value = "filterBySelect" });
        }
    }
}
