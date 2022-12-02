using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class AttachmentTypes
    {
        [Key]
        public int AttachmentTypeId { get; set; }
        public string AttachmentTypeDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool ForChangeRecordsOnly { get; set; }
        public bool IsOscaOnly { get; set; }
        public bool AllowMultiple { get; set; }
        public bool IsOnlyPdfAllowed { get; set; }
    } 
}
