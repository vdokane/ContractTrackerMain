using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    
    public class ContractQueryRepository : IContractQueryRepository
    {
        private readonly TrackerDbContext context;
        public ContractQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<Contracts?> GetContractById(int id)
        {
            var entity = await context.Contracts.FindAsync(id);
            return entity;
        }
    }
}
