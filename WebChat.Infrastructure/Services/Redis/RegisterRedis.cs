using StackExchange.Redis;
using WebChat.Redis;
using WebChat.Presistence.Repositories.RedisHelper;

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
      //  services.AddSingleton<IRedisService, RedisService>();
        // services.AddSingleton<IRedisService2<T>, RedisService2<T>>();

        services.AddSingleton(typeof(IRedisService2<>), typeof(RedisService2<>));

        services.AddSingleton<IUserDetailsService, UserDetailsService>();

        Console.WriteLine("--> Register RedisService");

        return services;
    }
}