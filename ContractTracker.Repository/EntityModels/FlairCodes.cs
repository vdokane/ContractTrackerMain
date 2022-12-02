using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class FlairCodes
    {
        [Key]
        public int FlairCodeId { get; set; }
        public string Org { get; set; } = string.Empty;
        public string EO { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string FlairAccountCode { get; set; } = string.Empty;
    }
}
