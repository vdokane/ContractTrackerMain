using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Repository.Interfaces
{
    public interface IUserQueryRepository
    {
        Task<Users> GetUserByLoginName(string userName);
    }
}
