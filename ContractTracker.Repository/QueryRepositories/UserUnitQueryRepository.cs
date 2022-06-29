using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContractTracker.Repository.QueryRepositories
{
    public class UserUnitQueryRepository : IUserUnitQueryRepository
    {
        private readonly TrackerDbContext context;
        public UserUnitQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<List<int>?> GetAllUnitIdsForAUser(int userId)
        {
            var unitIds = await context.UserUnits.Where(u => u.UserId == userId).Select(x => x.UnitId).ToListAsync();
            return unitIds;
        }
    }
}
