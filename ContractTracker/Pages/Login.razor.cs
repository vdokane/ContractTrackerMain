using Microsoft.AspNetCore.Components;
using ContractTracker.Authentication;
using ContractTracker.ClientModels.LoginModels;
using ContractTracker.ClientModels.Generic;
using Radzen;
using ContractTracker.Services;
using ContractTracker.Authentication.Models;
using System.Text;
using Newtonsoft.Json;

namespace ContractTracker.Pages
{
    public class LoginComponentBase : ComponentBase
    {
        #region injections
        [Inject]
        HttpClient Http { get; set; } = null!;

        [Inject]
        Blazored.LocalStorage.ILocalStorageService localStorage { get; set; } = null!;

        [Inject]
        Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider authenticationStateProvider { get; set; } = null!;

        [Inject]
        NavigationManager navigationManager { get; set; } = null!;

        [Inject]
        NotificationService notificationService { get; set; } = null!;
        [Inject]
        IAuthenticationService authenticationService { get; set; } = null!;

        [Inject]
        IUserService userService { get; set; } = null!;

        [Inject]
        IConfiguration config { get; set; } = null!;

        #endregion

        protected LoginComponentModel loginComponentModel;
        public LoginComponentBase()
        {
            loginComponentModel = new LoginComponentModel();
            loginComponentModel.DomainSelectItems.Add(new SelectComponetModel() { Text = "flaext", Value = "flaext" });
            loginComponentModel.DomainSelectItems.Add(new SelectComponetModel() { Text = "flcourts", Value = "flcourts" });

            //For quickly testing:
            loginComponentModel.Domain = "flcourts";
            loginComponentModel.Password = "word123";
            loginComponentModel.Username = "sally";
        }
        protected string userIdComponent { get; set; } = null!;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        protected async Task LoginUser()
        {
            var jwtResponse = await authenticationService.LoginJwt(loginComponentModel.Domain, loginComponentModel.Username, loginComponentModel.Password);  
            if(string.IsNullOrEmpty(jwtResponse))
            {
                notificationService.Notify(NotificationSeverity.Error, "Error!", "There was a problem!", 4000);
                return;
            }

            var localStorageModel = authenticationService.BuildLocalStorageModel(jwtResponse);
            var authConstants = new AuthConstants(config);
            await localStorage.SetItemAsync(authConstants.LocalStorageKeyForJwt, localStorageModel); 

            ((TrackerAuthenticationStateProvider)authenticationStateProvider).NotifyUserAuthenticaiton(jwtResponse);

            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;
            if (isUserAuthenticated == null || !isUserAuthenticated.Value)
            {
                notificationService.Notify(NotificationSeverity.Error, "Error!", "There was a problem!", 4000);
                return;
            }

            if(authState.User.Identity?.Name == null)
            {
                userIdComponent = "crap, name isn't working";
                return;
            }
            var userResponseModel = await userService.GetUserByUsername(authState.User.Identity.Name);

            //BIG TODO, if the user has an end date do not let them in the system!

            if (userResponseModel != null)
                userIdComponent = userResponseModel.UserId.ToString();
            else
                userIdComponent = "Couldn't find the user or no response";

            //FINALLY TODO, if user is good to go, send them to the hme page
            navigationManager.NavigateTo("sandbox");


        }

        protected async Task LogoutUser()
        {
            await ((TrackerAuthenticationStateProvider)authenticationStateProvider).NotifyUserLogout();
        }
    }
}
