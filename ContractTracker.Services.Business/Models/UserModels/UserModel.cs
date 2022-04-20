
namespace ContractTracker.Services.Business.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string? UserLogInName { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? PositionTitle { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
