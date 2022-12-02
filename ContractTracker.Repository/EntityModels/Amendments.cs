using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Amendments
    {
        [Key]
        public int AmendmentId { get; set; }
        public int ContractId { get; set; }
        public string ChangeType { get; set; } = string.Empty;
        public decimal AmendmentAmount { get; set; }
        public string AmendmentReference { get; set; } = string.Empty;
        public DateTime AmendmentEffectiveDate { get; set; }
        public DateTime ChangeDateExecuted { get; set; }
        public DateTime? NewEndingDate { get; set; }
        public string ChangeDescription { get; set; } = string.Empty;
        public DateTime Action { get; set; }
        
        public bool? MarkedForDeletion { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
