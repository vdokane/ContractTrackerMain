using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Repository.QueryRepositories
{
    public interface IUserQueryRepository
    {
        Task<Users> GetUserByLoginName(string loginName);
    }
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly TrackerDbContext context;
        public UserQueryRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task<Users> GetUserByLoginName(string loginName)
        {
            var user = await context.Users.Where(x => x.UserLogInName == loginName).FirstOrDefaultAsync();
            return user;
        }
    }
}
