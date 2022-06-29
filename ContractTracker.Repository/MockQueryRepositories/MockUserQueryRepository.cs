using ContractTracker.Repository.Context;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.EntityModels;


namespace ContractTracker.Repository.MockQueryRepositories
{
    public class MockUserQueryRepository : IUserQueryRepository
    {
        private readonly TrackerDbContext context;
        public MockUserQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
            //TODO, if this was truly mocked there should be a list to search by, find anyasync
        }

        public async Task<Users> GetUserByLoginName(string userName)
        {
            var entity = new Users()
            {
                AddDate = DateTime.Now,
                CreatedByUserId = 1,
                CreatedDate = DateTime.Now,
                EndDate = null,
                PositionTitle = "Mock User",
                UserEmail = "mock@user.org",
                UserId = 2,
                UserLogInName = @"flcourts\okaned",
                UserName = "David OKane",
                UserRoleId = 1
            };
            return await Task.FromResult(entity);
        }
    }
}
