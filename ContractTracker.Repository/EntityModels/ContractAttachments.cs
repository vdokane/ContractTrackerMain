using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractAttachments
    {
        [Key]
        public int ContractAttachmentId { get; set; }
        public int AttachmentTypeId { get; set; }
        public byte[] Attachment { get; set; } = null!;
        public string FileName { get; set; } = string.Empty;
    }
}
