using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContractTracker.Repository.EntityModels
{
    public class ApplicationSettings
    {
        [Key]
        public string Setting { get; set; } = null!;
        public string SettingValue { get; set; } = null!;
    }
}
