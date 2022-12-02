
namespace ContractTracker.Services.Business.Models.Logging
{
    public class ApplicationErrorLogModel
    {
        public string CurrentPage { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string CurrentUserName { get; set; } = string.Empty;
    }
}
