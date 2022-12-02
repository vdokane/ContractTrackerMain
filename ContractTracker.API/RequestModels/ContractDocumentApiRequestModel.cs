namespace ContractTracker.API.RequestModels
{
    public class ContractDocumentApiRequestModel
    {
        public int ContractId { get; set; }
        public int ContractDocumentTypeId { get; set; }
        public IFormFile ContractDocumentFormFile { get; set; } = null!;  
    }
}
