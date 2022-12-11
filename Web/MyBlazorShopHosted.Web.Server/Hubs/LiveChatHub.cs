using Microsoft.AspNetCore.SignalR;

namespace MyBlazorShopHosted.Web.Server.Hubs
{
    public class LiveChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", "Welcome. Please enter your message.");
        }

        public async Task SendMessageAsync(string message)
        {
            await Task.Delay(new TimeSpan(0, 0, 3));

            if (message.Contains("delivery", StringComparison.OrdinalIgnoreCase))
            {
                await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", "Delivery will take 5-7 days depending on location.");
            }
        }
    }
}
