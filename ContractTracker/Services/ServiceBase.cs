using Blazored.LocalStorage;
using ContractTracker.Authentication;

namespace ContractTracker.Services
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        protected readonly string baseUrlForApiSite;
        private readonly ILocalStorageService localStorage;

        public ServiceBase(HttpClient httpClient, IConfiguration configuration, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            baseUrlForApiSite = configuration.GetValue<string>("BaseUrlApi");
            this.localStorage = localStorage;
        }

        protected async Task SetJwtAuthHeader()
        {
            var authConstants = new AuthConstants(configuration);
            var localStorageKey = authConstants.LocalStorageKeyForJwt;
            var jwt = await localStorage.GetItemAsync<string>(localStorageKey);

            //got to be a better way than manually setting it... damn
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
        }

    }
}
