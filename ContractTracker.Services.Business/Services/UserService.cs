using ContractTracker.Repository.QueryRepositories;
using ContractTracker.Services.Business.Models;
using ContractTracker.Repository.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace ContractTracker.Services.Business.Services
{
    public interface IUserService
    {
        Task<UserModel?> GetUserByUserLoginName(string username);
    }
    public class UserService : IUserService 
    {
        private readonly IUserQueryRepository userQueryRepository;
        private readonly IUserUnitQueryRepository userUnitQueryRepository;
        public UserService(IUserQueryRepository userQueryRepository, IUserUnitQueryRepository userUnitQueryRepository)
        {
            this.userQueryRepository = userQueryRepository;
            this.userUnitQueryRepository = userUnitQueryRepository;
        }

        public async Task<UserModel?> GetUserByUserLoginName(string username)
        {
            var user = await userQueryRepository.GetUserByLoginName(username);
            if (user == null)
                return null;
            
            var model = new UserModel();
            model.UserId = user.UserId;
            model.UserName = user.UserName;
            //todo rest
            var unitIds = await userUnitQueryRepository.GetAllUnitIdsForAUser(user.UserId);
            if(unitIds != null)
            model.UserUnitIds = unitIds;

            return model;
        }
    }
}
