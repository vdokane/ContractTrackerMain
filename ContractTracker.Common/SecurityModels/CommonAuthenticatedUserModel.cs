
namespace ContractTracker.Common.SecurityModels
{
    //We could get email or something else, but this is only info from AD. Not from a particular application (like user role or user id)
    public class CommonAuthenticatedUserModel
    {
        public string UserName { get; set; } = string.Empty;

    }
}
