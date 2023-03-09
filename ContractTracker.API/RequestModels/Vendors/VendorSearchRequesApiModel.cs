using ContractTracker.API.RequestModels.Shared;

namespace ContractTracker.API.RequestModels.Vendors
{
    public class VendorSearchRequesApiModel : SearchRequestBaseApiModel
    {
        public string FilterByVendorType { get; set; } = string.Empty;
        public string FilterByVendorNumber { get; set; } = string.Empty;
        public string FilterBySequenceNumber { get; set; } = string.Empty;
        public string FilterByPurchasingName { get; set; } = string.Empty;
    }
}
