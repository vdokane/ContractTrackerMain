using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractUserTypes
    {
        [Key]
        public int ContractUserTypeId { get; set; }
        public string UserTypeDescription { get; set; } = string.Empty;
        public int IsActive { get; set; }
    }
}
