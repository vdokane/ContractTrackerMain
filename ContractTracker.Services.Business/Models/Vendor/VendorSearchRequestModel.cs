using ContractTracker.Services.Business.Models.Shared;

namespace ContractTracker.Services.Business.Models.Vendor
{
    public class VendorSearchRequestModel : SearchRequestBaseModel
    {
        public string FilterByVendorType { get; set; } = string.Empty;
        public string FilterByVendorNumber { get; set; } = string.Empty;
        public string FilterBySequenceNumber { get; set; } = string.Empty;
        public string FilterByPurchasingName { get; set; } = string.Empty;
    }
}
