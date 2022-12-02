using ContractTracker.Repository.Context;
using ContractTracker.Repository.EntityModels;
using ContractTracker.Repository.Interfaces;

namespace ContractTracker.Repository.CommandRepositories
{
    public interface IApplicationErrorLogCommandRepository
    {
        Task InsertApplicationErrorLog(ApplicationErrorLogs applicationErrorLogs);
    }
    public class ApplicationErrorLogCommandRepository : IApplicationErrorLogCommandRepository
    {
        private readonly TrackerDbContext context;
        public ApplicationErrorLogCommandRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.GetContext();
        }

        public async Task InsertApplicationErrorLog(ApplicationErrorLogs applicationErrorLogs)
        {
            context.ApplicationErrorLogs.Add(applicationErrorLogs);
            await context.SaveChangesAsync();
        }
    }
}
