namespace ContractTracker.Authentication.Models
{
    public class AuthUserRequestModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Domain { get; set; }
    }
}
