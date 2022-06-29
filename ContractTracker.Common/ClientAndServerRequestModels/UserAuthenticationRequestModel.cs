namespace ContractTracker.Common.ClientAndServerRequestModels
{
    public class UserAuthenticationRequestModel
    {
        public string Domain { get; set; }  = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
