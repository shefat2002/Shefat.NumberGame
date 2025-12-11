using Microsoft.AspNetCore.SignalR;

namespace Shefat.NumberGame.Hubs;

public class NumberHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client Connected!: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"Client Disconnected!: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }
}