using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;

public class MessageHub : Hub
{
    private static ConcurrentDictionary<string, string> _users = new ConcurrentDictionary<string, string>();

    public override Task OnConnectedAsync()
    {
        string userName = Context.GetHttpContext().Request.Query["user"];
        _users[Context.ConnectionId] = userName;
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _users.TryRemove(Context.ConnectionId, out _);
        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string user, string message)
    {
        foreach (var connection in _users)
        {
            if (connection.Value == user)
            {
                await Clients.Client(connection.Key).SendAsync("ReceiveMessage", user, message);
            }
        }
    }
}
