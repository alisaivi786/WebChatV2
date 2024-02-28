
using IdleConnectionService.Services;

namespace IdleConnectionService
{
    public class Worker(ILogger<Worker> logger, ICustomHubContextService customHubContextService) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;

        private readonly ICustomHubContextService _customHubContextService = customHubContextService;

        private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(1); // Adjust the interval as needed

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // await Task.Delay(_checkInterval, stoppingToken);
                await Task.Delay(10000, stoppingToken);
                //  await _hubContext.Clients.All.SendAsync("CheckIdleConnections");

                await Console.Out.WriteLineAsync("Service Started");
               // _customHubContextService.SendMessageToClients("Checking idle connections");
                await _customHubContextService.CheckIdleConnections();
            }
        }
    }
}
