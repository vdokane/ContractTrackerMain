using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class VendorSearch_Result
    {
        public int MaxRows { get; set; }
        public long RowNum { get; set; } //ROW_NUMBER is sql is "long"
        public int VendorId { get; set; }
        public string VendorType { get; set; } = string.Empty;
        public string VendorNumber { get; set; } = string.Empty;
        public string SequenceNumber { get; set; } = string.Empty;
        public string PurchasingNameLine1 { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
    }
}
