using Microsoft.AspNetCore.SignalR;

namespace Aqua.Web;

public class SignalrHub : Hub
{
    public async Task NewMessage(string user, string message)
    {
        await Clients.All.SendAsync("messageReceived", user, message);
    }
}