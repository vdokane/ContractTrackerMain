using ContractTracker.Repository.CommandRepositories;
using ContractTracker.Services.Business.Models.Logging;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;

namespace ContractTracker.Services.Business.ApplicationServices
{
    public interface IApplicationErrorService
    {
        Task SaveClientError(ApplicationErrorLogModel model);
    }
    public class ApplicationErrorService : IApplicationErrorService
    {
        private readonly IApplicationErrorLogCommandRepository applicationErrorLogCommandRepository;
        public ApplicationErrorService(IApplicationErrorLogCommandRepository applicationErrorLogCommandRepository)
        {
            this.applicationErrorLogCommandRepository = applicationErrorLogCommandRepository;
        }

        public async Task SaveClientError(ApplicationErrorLogModel model)
        {
            
            try
            {
                var newEntity = new ApplicationErrorLogs();
                newEntity.ErrorMessage = model.ErrorMessage;
                newEntity.UserId = model.CurrentUserId;
                newEntity.ClientUrl = model.CurrentPage;
                newEntity.InsertDate = DateTime.Now;
                newEntity.UserName = model.UserName;

                await applicationErrorLogCommandRepository.InsertApplicationErrorLog(newEntity);
            }
            catch
            {
                //fail silently since we are already in error state
            }
        }
    }
}
