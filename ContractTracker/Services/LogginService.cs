using Newtonsoft.Json;
using ContractTracker.Infrastructure;
using Blazored.LocalStorage;
using System.Text;
using ContractTracker.Common.ClientAndServerModels.Logging;

namespace ContractTracker.Services
{
    public interface ILogginService
    {
        Task SaveClientError(string currentPage, Exception exception);
    }
    public class LogginService : ServiceBase, ILogginService
    {
        public LogginService(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage) : base(httpClient, configuration, localStorage)
        {
        }

        public async Task SaveClientError(string currentPage, Exception exception)
        {
            var loggingModel = new LoggingModel() { CurrentPage = currentPage, Message= exception.ToString() };
            var route = baseUrlForApiSite + ServiceRoutes.Logging.GetSaveClientErrorUrl();
            await SetJwtAuthHeader();
            var serialized = JsonConvert.SerializeObject(loggingModel);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(route, stringContent);
        }
    }
}
