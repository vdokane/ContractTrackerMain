namespace ContractTracker.Services.Authentication.Models
{
    public class AuthenticationResponseModel
    {
        public AuthenticationResponseModel()
        {
            IsVerified = false;
        }
        public bool IsVerified { get; set; }

    }
}
