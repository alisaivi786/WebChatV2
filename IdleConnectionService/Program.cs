using IdleConnectionService.Services;

namespace IdleConnectionService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddSignalR();

            builder.Services.AddSingleton<ICustomHubContextService, CustomHubContextService>();

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}