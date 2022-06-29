using ContractTracker.ClientModels.Generic;

namespace ContractTracker.ClientModels.LoginModels
{
    public class LoginComponentModel
    {
        public List<SelectComponetModel> DomainSelectItems { get; set; } = new List<SelectComponetModel>();
        
        public string Domain { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
