using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class Units
    {
        [Key]
        public int UnitId { get; set; }
        public string Bureau { get; set; }
        public string SectionDesc { get; set; }
        public string Section { get; set; }
        public string UnitCode { get; set; }
        public bool? AllUsersCanSubmit { get; set; }
        public bool? PurchaseRequiresSpecialRouting { get; set; }
    }
}
