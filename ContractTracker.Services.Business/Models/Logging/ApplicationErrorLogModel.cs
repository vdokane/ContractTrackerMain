
namespace ContractTracker.Services.Business.Models.Logging
{
    public class ApplicationErrorLogModel
    {
        public string CurrentPage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public int CurrentUserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
