using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.QueryRepositories;
using ContractTracker.Services.Business.Services;


namespace ContractTracker.Services.Business.Factories
{
    public class BusinessServiceFactory
    {
        private readonly IUnitOfWork unitOfWork;

        public BusinessServiceFactory(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public IAnnouncementService BuildAnnouncementService()
        {
            IAnnouncementQueryRepository repo = new AnnouncementQueryRepository(unitOfWork);
            return new AnnouncementService(repo);
        }
        
        //todo build repo 
        public IApplicationSettingsService BuidApplicationSettingsService()
        {
            return new ApplicationSettingsService();
        }

        public IContractService BuidContractService()
        {
            ICaseQueryRepository caseQueryRepository = new CaseQueryRepository(unitOfWork);
            return new ContractService(caseQueryRepository);
        }

        public IUserService BuidUserService()
        {
            return new UserService();
        }
             
    }
}
