﻿using ContractTracker.ClientModels.Controls.Grid;
using ContractTracker.ClientModels.Generic;
using Microsoft.AspNetCore.Components;

namespace ContractTracker.Controls.Grid.Filters
{
    //This was just testing
    public class DropDownFilerComponent
    {
        public List<SelectComponetModel> HardCodedSelectOptions = new List<SelectComponetModel>();
        public string Text { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public class DropDownFilterBase : ComponentBase
    {
        [Parameter]
        public EventCallback<GridDelegateModel> OnChangeCallback { get; set; }

        [Parameter]
        public string FilterId { get; set; } = string.Empty;
        
        [Parameter]
        public string PreSelectedValue { get; set; } = string.Empty;

        [Parameter]
        public List<SelectComponetModel> Options { get; set; }  = new List<SelectComponetModel>();


        //public string NameOfThisFilter { get; set; }

        protected readonly DropDownFilterParamterModel dropDownFilterParamterModel;

        protected DropDownFilerComponent dropDownFilerComponent; //just testing

        public DropDownFilterBase()
        {

            dropDownFilerComponent = new DropDownFilerComponent();
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "one", Value = "1" });
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "two", Value = "2" });
            dropDownFilerComponent.HardCodedSelectOptions.Add(new SelectComponetModel() { Text = "three", Value = "3" });

            //NameOfThisFilter = "fromConstructor";


            dropDownFilterParamterModel = new DropDownFilterParamterModel();
        }

        protected override async Task OnInitializedAsync()
        {
            dropDownFilerComponent.Value = "two";
            await base.OnInitializedAsync();
        }

        //TODO delete myself event

        protected async Task ValueChanged(string newValue)
        {
            Console.WriteLine(newValue);
            dropDownFilerComponent.Value = newValue;
            
            var gridDelegateModel = new GridDelegateModel();
            gridDelegateModel.FilterId = FilterId;
            gridDelegateModel.FilterValue = newValue;
            gridDelegateModel.EventType = "ValueChange"; //todo this needs to be an enum or something type safe to manage all the different event types a component filter can emit

            await OnChangeCallback.InvokeAsync(gridDelegateModel);
        }

        protected async Task RemoveMe()
        {
            Console.WriteLine("DropDown Filter RemoveMe clicked");
            var gridDelegateModel = new GridDelegateModel();
            gridDelegateModel.FilterId = FilterId;
            gridDelegateModel.EventType = "RemoveMe"; //todo this needs to be an enum or something type safe to manage all the different event types a component filter can emit

            await OnChangeCallback.InvokeAsync(gridDelegateModel);
        }



    }

}
