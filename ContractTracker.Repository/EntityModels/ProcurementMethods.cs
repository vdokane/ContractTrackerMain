using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ProcurementMethods
    {
        [Key]
        public int ProcurementMethodId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string ProcurementMethodDescription { get; set; } = string.Empty;
        public string Exemption { get; set; } = string.Empty;
        public bool ProcurementDocumentRequired { get; set; }
        public bool Active { get; set; }
    }
}
