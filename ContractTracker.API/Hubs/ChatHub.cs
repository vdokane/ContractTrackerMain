using Microsoft.AspNetCore.SignalR;
using System.Text;

namespace ContractTracker.API.Hubs
{
    //https://learn.microsoft.com/en-us/aspnet/core/signalr/hubs?view=aspnetcore-7.0
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {

            var sb = new StringBuilder(message).Append(System.DateTime.Now.ToString());
            await Clients.All.SendAsync("ReceiveMessage", user, sb.ToString());
        }

        /*
        public async Task<string> WaitForMessage(string connectionId)
        {
            var message = await Clients.Client(connectionId).InvokeAsync<string>(
                "GetMessage");
            return message;
        } */
    }
}
