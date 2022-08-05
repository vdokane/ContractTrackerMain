namespace ContractTracker.Common.ClientAndServerModels.Authentication
{
    public class UserAuthenticationRequestModel
    {
        public string Domain { get; set; }  = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
