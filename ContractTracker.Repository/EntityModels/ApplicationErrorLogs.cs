using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class ApplicationErrorLogs
    {
        [Key]
        public int ApplicationErrorLogId { get; set; }
        public string ClientUrl { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? InsertDate { get; set; }
    }
}
