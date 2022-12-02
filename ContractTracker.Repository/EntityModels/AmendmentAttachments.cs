using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class AmendmentAttachments
    {
        [Key]
        public int AmendmentAttachmentId { get; set; }
        public int AmendmentId { get; set; }
        public int RedactedForAmendmentAttachmentId { get; set; }
        public int AttachmentTypeId { get; set; }
        public byte[] Attachment { get; set; } = null!;
        public string AttachmentFilename { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public int CreateByUserId { get; set; }
        public int? FACTSDocumentID { get; set; } //--this needs to be renamed (or if I get rid the the Contract app, removed completely)
        public bool? MarkedForDeletion { get; set; }
    }
}

