using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ContractTracker.Repository.QueryRepositories
{
    public interface ICaseQueryRepository {
        Task<Contracts> GetContractById(int id);
    }
    public class CaseQueryRepository : ICaseQueryRepository
    {
        private readonly TrackerDbContext context;
        public CaseQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<Contracts> GetContractById(int id)
        {
            var entity = await context.Contracts.FindAsync(id);
            return entity;
        }
    }
}
