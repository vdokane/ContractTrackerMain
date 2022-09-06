using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using ContractTracker.Authentication;
using Blazored.LocalStorage;
using Radzen;
using Microsoft.Extensions.Configuration.Memory;

namespace ContractTracker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");  //??

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore(); //Part of NuGet Microsoft.AspNetCore.Components.Authorization;
            builder.Services.AddScoped<AuthenticationStateProvider, TrackerAuthenticationStateProvider>();
            
            //Client services
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<Services.IUserService, Services.UserService>();
            builder.Services.AddScoped<Services.IVendorService, Services.VendorService>();
            builder.Services.AddScoped<Services.ISandboxService, Services.SandboxService>();
             

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<NotificationService>(); //For toasts
          
            //Do not store these in any setting or json file, the client will see them. Set them in memory for safe keeping!!
            //NOTE: The client will not be making any direct DB calls so there is no need for a db connection string anywhere!
            var appsettings = new Dictionary<string, string>()
            {
                { "LocalStorageKeyForAuthUserModel", "12sad20d0s-23-ds-@ad-2sdsod8" },
                { "LocalStorageKeyForJwt", "OS82LzIwMjIgNzoyMzo1MyBQTQ" },
            };
            var memoryConfig = new MemoryConfigurationSource { InitialData = appsettings };
            builder.Configuration.Add(memoryConfig);

            await builder.Build().RunAsync();
        }
    }
}