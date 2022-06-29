namespace ContractTracker.Repository.Interfaces
{
    public interface IUserUnitQueryRepository
    {
        Task<List<int>?> GetAllUnitIdsForAUser(int userId);
    }
}
