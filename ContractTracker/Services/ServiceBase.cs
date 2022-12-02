using Blazored.LocalStorage;
using ContractTracker.Authentication;
using ContractTracker.Authentication.Models;

namespace ContractTracker.Services
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient httpClient;
        private readonly IConfiguration configurationBase;
        protected readonly string baseUrlForApiSite;
        private readonly ILocalStorageService localStorageBase;

        public ServiceBase(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.configurationBase = configuration;
            baseUrlForApiSite = configuration.GetValue<string>("BaseUrlApi");
            this.localStorageBase = localStorage;
        }

        protected async Task SetJwtAuthHeader()
        {
            var authConstants = new AuthConstants(configurationBase);
            var localStorageKey = authConstants.LocalStorageKeyForJwt;
            var localStorageModel = await localStorageBase.GetItemAsync<LocalStorageModel>(localStorageKey);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", localStorageModel.sdoj22sd0sld);
        }

    }
}
