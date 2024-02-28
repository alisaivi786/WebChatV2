using StackExchange.Redis;
using WebChat.Redis;

namespace WebChat.Infrastructure.Services.Redis;

public static class RegisterRedis
{
    public static IServiceCollection AddRegisterRedis(this IServiceCollection services)
    {
        // Register the IConnectionMultiplexer as a singleton
        services.AddSingleton<IConnectionMultiplexer>(provider =>
        {
            var appSettings = provider.GetRequiredService<IAppSettings>();
            var connectionMultiplexer = ConnectionMultiplexer.Connect(appSettings.RedisConnectionString);
            return connectionMultiplexer;
        });

        //services.AddScoped<IRedisService, RedisService>();
        services.AddSingleton<IRedisService, RedisService>();
        Console.WriteLine("--> Register RedisService");

        return services;
    }
}