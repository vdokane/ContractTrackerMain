using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class Amendments
    {
        [Key]
        public int AmendmentId { get; set; }
        public int ContractId { get; set; }
        public string ChangeType { get; set; }
        public decimal AmendmentAmount { get; set; }
        public string AmendmentReference { get; set; }
        public DateTime AmendmentEffectiveDate { get; set; }
        public DateTime ChangeDateExecuted { get; set; }
        public DateTime? NewEndingDate { get; set; }
        public string ChangeDescription { get; set; }
        public DateTime Action { get; set; }
        
        [ForeignKey("AmendedAttachmentId")]
        public int? AmendedAttachmentId { get; set; }
        public AmendmentAttachments AmendmentAttachments { get; set; }

        [ForeignKey("RedactedAttachmentId")]
        public int? RedactedAttachmentId { get; set; }
        public AmendmentAttachments RedactedAmendmentAttachments { get; set; } //TODO, I think
        public bool? MarkedForDeletion { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
