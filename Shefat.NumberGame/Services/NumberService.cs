using Microsoft.AspNetCore.SignalR;
using Shefat.NumberGame.Hubs;

namespace Shefat.NumberGame.Services;

public class NumberService : INumberService
{
    private readonly IHubContext<NumberHub> _hubContext;

    public NumberService(IHubContext<NumberHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task<int[]> GenerateNumbersAsync(int count)
    {
        int[] zeros = Enumerable.Repeat(0, count).ToArray();
        await _hubContext.Clients.All.SendAsync("ReceiveZeroGeneration", count, zeros);
        return zeros;
    }
}