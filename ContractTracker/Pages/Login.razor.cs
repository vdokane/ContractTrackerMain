using Microsoft.AspNetCore.Components;
using ContractTracker.Authentication;
using ContractTracker.ClientModels.LoginModels;
using ContractTracker.ClientModels.Generic;
using Radzen;
using ContractTracker.Services;

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
            decimal dBug = -1;
            
            var jwtResponse = await authenticationService.LoginJwt(loginComponentModel.Domain, loginComponentModel.Username, loginComponentModel.Password);  

            if(string.IsNullOrEmpty(jwtResponse))
            {
                notificationService.Notify(NotificationSeverity.Error, "Error!", "There was a problem!", 4000);
                return;
            }

            //TODO, figure out a good way to expire this
            var authConstants = new AuthConstants(config);
            await localStorage.SetItemAsync(authConstants.LocalStorageKeyForJwt, jwtResponse); 

            ((TrackerAuthenticationStateProvider)authenticationStateProvider).NotifyUserAuthenticaiton(jwtResponse);

            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            var isUserAuthenticated = authState.User.Identity?.IsAuthenticated;
            if (isUserAuthenticated == null || !isUserAuthenticated.Value)
            {
                notificationService.Notify(NotificationSeverity.Error, "Error!", "There was a problem!", 4000);
                return;
            }

            //Note, this must be added first so the API's that validate the user can have authentication.
            Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtResponse);

            //Next get the user from the DB. Make sure that not only the user has been authenticated but they are also a user in our system. 



            //TODO figure out injection for user services
            //IUserService userServices = new UserService(Http);
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
                userIdComponent = "crap, no response";

            //FINALLY TODO, if user is good to go, send them to the hme page navigationManager.NavigateTo("counter");


        }
    }
}
