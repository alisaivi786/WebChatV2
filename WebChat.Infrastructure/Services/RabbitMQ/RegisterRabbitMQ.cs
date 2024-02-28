
using RabbitMQ.Client;
using WebChat.RabbitMQ;

namespace WebChat.Infrastructure.Services.RabbitMQ;

public static class RegisterRabbitMQ
{
    public static IServiceCollection AddRegisterRabbitMQ(this IServiceCollection services, IAppSettings appSettings)
    {

        services.AddSingleton(new ConnectionFactory
        {
            HostName = appSettings.RabbitMqHost ?? "127.0.0.1",
            UserName = appSettings.RabbitMqUserName ?? "test",
            Password = appSettings.RabbitMqPassword ?? "test",
            AutomaticRecoveryEnabled = true
        });

        //  services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
        //  services.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();      

        services.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();
        services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();

        return services;
    }
}
