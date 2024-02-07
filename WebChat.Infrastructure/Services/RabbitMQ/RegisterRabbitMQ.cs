
using RabbitMQ.Client;
using WebChat.RabbitMQ;

namespace WebChat.Infrastructure.Services.RabbitMQ;

public static class RegisterRabbitMQ
{
    public static IServiceCollection AddRegisterRabbitMQ(this IServiceCollection services, AppSettings appSettings)
    {

        services.AddSingleton(new ConnectionFactory
        {
            HostName = appSettings.RabbitMqHost,
            UserName = appSettings.RabbitMqUserName,
            Password = appSettings.RabbitMqPassword
        });

        services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
        services.AddScoped<IRabbitMQConsumer, RabbitMQConsumer>();

        return services;
    }
}
