namespace ContractTracker.ClientModels.DocumentUploadModels
{
    //Do not put this in Common. There will not be a reference to IFormFile. 
    public class ContractDocumentApiRequestModel
    {
        public int ContractId { get; set; }
        public int ContractDocumentTypeId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public Stream ContractDocumentFormFile { get; set; } = null!; //No IFormFile in native web assembly? Shit.
    }
}
