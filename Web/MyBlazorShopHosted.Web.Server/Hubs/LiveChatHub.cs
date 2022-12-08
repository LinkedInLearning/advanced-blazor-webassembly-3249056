using Microsoft.AspNetCore.SignalR;

namespace MyBlazorShopHosted.Web.Server.Hubs
{
    public class LiveChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", "Welcome. Please enter your message.");
        }
    }
}
