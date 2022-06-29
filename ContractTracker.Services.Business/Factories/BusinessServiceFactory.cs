using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.MockQueryRepositories;
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
            //todo, fix misspelling
            IContractQueryRepository contractQueryRepository = new ContractQueryRepository(unitOfWork);
            return new ContractService(contractQueryRepository);
        }

        //TODO, this is another one you need to mock for testing in the cloud
        public IUserService BuidUserService(bool useMock)
        {
            IUserUnitQueryRepository userUnitQueryRepository;
            IUserQueryRepository userQueryRepository;

            if(useMock)
            {
                 userUnitQueryRepository = new MockUserUnitQueryRepository(unitOfWork);  
                 userQueryRepository = new MockUserQueryRepository(unitOfWork);
            }
            else
            {
                 userUnitQueryRepository = new UserUnitQueryRepository(unitOfWork);
                 userQueryRepository = new UserQueryRepository(unitOfWork);
            }

            return new UserService(userQueryRepository, userUnitQueryRepository);
        }
             
    }
}
