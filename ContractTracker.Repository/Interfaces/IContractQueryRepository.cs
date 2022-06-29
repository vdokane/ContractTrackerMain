using ContractTracker.Repository.EntityModels;

namespace ContractTracker.Repository.Interfaces
{
    public interface IContractQueryRepository
    {
        Task<Contracts?> GetContractById(int id);
    }
}
