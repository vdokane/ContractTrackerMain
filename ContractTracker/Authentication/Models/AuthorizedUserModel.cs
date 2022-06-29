namespace ContractTracker.Authentication.Models
{
    public class AuthorizedUserModel
    {
        public string? Role { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
    }
}
