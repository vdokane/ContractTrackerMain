namespace ContractTracker.Common.ClientAndServerRequestModels.UserModels
{
    public class UserResponseModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; //This needs to be a constant or enum..something
        public List<int> UserUnitIds { get; set; } = new List<int>();

        //TODO, other stuff?
    }
}
