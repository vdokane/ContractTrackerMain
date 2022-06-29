using ContractTracker.Repository.Context;
using ContractTracker.Repository.Interfaces;
 
namespace ContractTracker.Repository.MockQueryRepositories
{
    public class MockUserUnitQueryRepository : IUserUnitQueryRepository
    {
        private readonly TrackerDbContext context;
        public MockUserUnitQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
            //TODO, if this was truly mocked there should be a list to search by, find anyasync
        }

        public async Task<List<int>?> GetAllUnitIdsForAUser(int userId)
        {
            return await Task.FromResult(new List<int> { 1,2 });
        }
    }
}
