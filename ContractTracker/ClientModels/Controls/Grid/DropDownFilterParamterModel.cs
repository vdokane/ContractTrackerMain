﻿using ContractTracker.ClientModels.Generic;

namespace ContractTracker.ClientModels.Controls.Grid
{
    //TODO delete me
    public class DropDownFilterParamterModel
    {
        public string FilterId { get; set; } = string.Empty;
        public string PreSelectedValue = string.Empty;
        public List<SelectComponetModel> Options = new List<SelectComponetModel>();
    }
}