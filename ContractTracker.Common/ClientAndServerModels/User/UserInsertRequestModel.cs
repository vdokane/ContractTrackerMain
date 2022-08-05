namespace ContractTracker.Common.ClientAndServerModels.User
{
    public class UserInsertRequestModel
    {
        public string UserName { get; set; } = string.Empty;   
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public int UserRoleId { get; set; } = 0;
        public int UnitId { get; set; } = 0;

    }
}
