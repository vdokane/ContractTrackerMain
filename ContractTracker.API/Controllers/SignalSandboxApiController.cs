using ContractTracker.API.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text;

namespace ContractTracker.API.Controllers
{
    [Route("api/signalsandbox")]
    [ApiController]
    //https://learn.microsoft.com/en-us/aspnet/core/signalr/hubcontext?view=aspnetcore-7.0
    public class SignalSandboxApiController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;
        public SignalSandboxApiController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpGet("saveclienterror")]
        public async Task<string> TestChatHub(string msg)
        {
            //await hubContext.Clients.All.SendAsync("Notify", $"Home page loaded at: {DateTime.Now}");
            var sb = new StringBuilder(msg).Append(System.DateTime.Now.ToString());
            await hubContext.Clients.All.SendAsync("ReceiveMessage", "tst1", sb.ToString());
            return "signalsandbox works";
        }
    }
}
