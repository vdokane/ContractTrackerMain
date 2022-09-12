using ContractTracker.Common.ClientAndServerModels.Exception;

namespace ContractTracker.Common.ClientAndServerModels.User
{
    public class UserResponseModel : BaseResponseModel
    {
        public int UserId { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; //This needs to be a constant or enum..something
        public List<int> UserUnitIds { get; set; } = new List<int>();

        //TODO, other stuff?
    }
}
