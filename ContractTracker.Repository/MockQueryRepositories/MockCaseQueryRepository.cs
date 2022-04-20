using ContractTracker.Repository.QueryRepositories;
using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.MockQueryRepositories
{
    
    public class MockCaseQueryRepository : ICaseQueryRepository
    {
        private readonly TrackerDbContext context;
        public MockCaseQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<Contracts> GetContractById(int id)
        {
            return await Task.FromResult(new Contracts() {
                ContractId = id,
                AdministrativeCostPercentage="s"
                //todo ..everything
            });
        }
    }
}
