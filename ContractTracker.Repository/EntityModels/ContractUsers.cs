using System.ComponentModel.DataAnnotations;

namespace ContractTracker.Repository.EntityModels
{
    public class ContractUsers
    {
		[Key]
		public int ContractUserId { get; set; }
		public int ContractId { get; set; }
		public int UserId { get; set; }
		public int ContractUserTypeId { get; set; }
		public int CreatedByUserId { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
