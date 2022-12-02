using ContractTracker.Services.Business.Models.Logging;

namespace ContractTracker.Services.Business.ApplicationServices
{
    public interface IApplicationLoggingService
    {
        Task SaveClientErrorLog(ApplicationErrorLogModel model);
    }
    public class ApplicationLoggingService : IApplicationLoggingService
    {
        public ApplicationLoggingService() { }
        public async Task SaveClientErrorLog(ApplicationErrorLogModel model)
        {
            decimal dBug = -1;
        }
    }
}
