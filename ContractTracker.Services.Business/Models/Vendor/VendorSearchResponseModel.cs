using ContractTracker.Services.Business.Models.Shared;

namespace ContractTracker.Services.Business.Models.Vendor
{
    public class VendorSearchResponseModel : SearchResponseBaseModel
    {
        public List<VendorSearchDataModel> SearchResults = new List<VendorSearchDataModel>();
    }

    public class VendorSearchDataModel
    {
        public int VendorId { get; set; }
        public string VendorType { get; set; } = string.Empty;
        public string VendorNumber { get; set; } = string.Empty;
        public string SequenceNumber { get; set; } = string.Empty;
        public string PurchasingNameLine1 { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
    }
}
