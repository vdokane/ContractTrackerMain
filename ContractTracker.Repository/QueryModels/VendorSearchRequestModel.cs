namespace ContractTracker.Repository.QueryModels
{
    public class VendorSearchRequestModel : GridRequestModel
    {
        public string FilterByVendorType { get; set; } = string.Empty;
        public string FilterByVendorNumber { get; set; } = string.Empty;
        public string FilterBySequenceNumber { get; set; } = string.Empty;
        public string FilterByPurchasingName { get; set; } = string.Empty;
    }
}
