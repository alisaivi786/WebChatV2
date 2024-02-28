
using Microsoft.AspNetCore.SignalR;
using WebChat.Hubs;

namespace IdleConnectionService.Services;

public class CustomHubContextService : ICustomHubContextService
{
    private readonly IHubContext<ChatHub> _hubContext;

    public CustomHubContextService(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public void SendMessageToClients(string message)
    {
        //_hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task CheckIdleConnections()
    {

        try
        {
            await _hubContext.Clients.All.SendAsync("CheckIdleConnections");
            await Console.Out.WriteLineAsync("Sent to CheckIdleConnections");
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }
}