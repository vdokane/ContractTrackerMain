using ContractTracker.Repository.DocumentHelpers;
using ContractTracker.Repository.Interfaces;
using ContractTracker.Repository.MockQueryRepositories;
using ContractTracker.Repository.QueryRepositories;
using ContractTracker.Services.Business.Services;
using ContractTracker.Services.Business.ApplicationServices;
using ContractTracker.Repository.CommandRepositories;

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
        
        public IContractService BuidContractService()
        {
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

        public IContractAttachmentService BuildContractDocumentService(bool useMock)
        {
            IContractAttachmentQueryRepository repo;
            if(useMock)
            {
                FileSystemRepository fileSystemRepository = new FileSystemRepository();
                repo = new MockContractAttachmentQueryRepository(fileSystemRepository);
            }
            else
            {
                repo = new ContractAttachmentQueryRepository(unitOfWork);
            }
            return new ContractAttachmentService(repo);
        }

       

        #region application services
        //This will capture errors from client and save to the DB only. 
        public IApplicationErrorService BuildApplicationErrorService()
        {
            IApplicationErrorLogCommandRepository applicationErrorLogCommandRepository = new ApplicationErrorLogCommandRepository(unitOfWork);
            return new ApplicationErrorService(applicationErrorLogCommandRepository);
        }

        //TODO, do I want to write to the file system log if db is down? How will that act in a cloud instance or container?
        //TODO2, am I building uneeded stuff here? I mean, what else do I log, can error do the same?
        //public IApplicationLoggingService BuildLoggingService()
        //{
          //  var loggingService = new ApplicationLoggingService();
            //return loggingService;
        //}

        //todo build repo 
        public IApplicationSettingsService BuidApplicationSettingsService()
        {
            return new ApplicationSettingsService();
        }

        #endregion
    }
}
