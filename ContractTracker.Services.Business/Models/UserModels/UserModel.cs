
namespace ContractTracker.Services.Business.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string UserLogInName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string? PositionTitle { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public List<int> UserUnitIds { get; set; } = new List<int>();
    }
}
