
namespace ContractTracker.Services.Business.Models.FileUploadModels
{
    public class UploadedDocumentRequestModel
    {
        public string FileName { get; set; } = string.Empty;
        public string GeneratedFileName { get; set; } = string.Empty;
        public byte[] FileContent { get; set; } = null!;
        public string FileContentType { get; set; } = string.Empty;
    }
}
