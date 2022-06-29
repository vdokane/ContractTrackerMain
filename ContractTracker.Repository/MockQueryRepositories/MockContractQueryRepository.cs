using ContractTracker.Repository.QueryRepositories;
using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;


namespace ContractTracker.Repository.MockQueryRepositories
{
    
    public class MockContractQueryRepository : IContractQueryRepository
    {
        private readonly TrackerDbContext context;
        public MockContractQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<Contracts?> GetContractById(int id)
        {
            return await Task.FromResult(new Contracts() {
                ContractId = id,
                AdministrativeCostPercentage="s"
                //todo ..everything
            });
        }
    }
}
