using Microsoft.AspNetCore.Components;
using ContractTracker.ClientModels;
using ContractTracker.Services;
using ContractTracker.Common.ClientAndServerModels.Vendor;
using ContractTracker.Controls.Grid;
using ContractTracker.ClientModels.Generic;
using ContractTracker.ClientModels.Controls.Grid;
using ContractTracker.Infrastructure;
using System.Reflection;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;


namespace ContractTracker.Pages
{
    public class SignalRSandBoxComponentBase : ComponentBase, IAsyncDisposable
    {
        [Inject]
        NavigationManager Navigation { get; set; }

        protected HubConnection? hubConnection;
        protected List<string> messages = new List<string>();
        protected string? userInput;
        protected string? messageInput;
        protected bool showClass = false;

        protected override async Task OnInitializedAsync()
        {
            const string tst = @"http://localhost:25940/chathub";
            hubConnection = new HubConnectionBuilder()
            //.WithUrl(Navigation.ToAbsoluteUri("/chathub"))
            .WithUrl(tst)
            .Build();

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var encodedMsg = $"{user}: {message}";
                messages.Add(encodedMsg);
                showClass = true;
                InvokeAsync(StateHasChanged);
            });

            await hubConnection.StartAsync();

            await base.OnInitializedAsync();
        }
        protected async Task Send()
        {
            if (hubConnection is not null)
            {
                await hubConnection.SendAsync("SendMessage", userInput, messageInput);
            }
        }

        public bool IsConnected =>
            hubConnection?.State == HubConnectionState.Connected;

        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
    }
}
