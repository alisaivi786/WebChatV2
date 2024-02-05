
using RabbitMQ.Client;
using StackExchange.Redis;
using WebChat.RabbitMQ;
using WebChat.Redis;

namespace WebChat.Infrastructure.DI.Redis;

public static class RegisterRedis
{
    public static IServiceCollection AddRegisterRedis(this IServiceCollection services, AppSettings appSettings)
    {
        //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(appSettings.RedisConnectionString);
        //IDatabase db = redis.GetDatabase(15);

        //services.AddSingleton<ConnectionFactory>(new ConnectionFactory
        //{
        //    HostName = appSettings.RabbitMqHost,
        //    UserName = appSettings.RabbitMqUserName,
        //    Password = appSettings.RabbitMqPassword
        //});

        services.AddScoped<IRedisService, RedisService>();

        return services;
    }
}