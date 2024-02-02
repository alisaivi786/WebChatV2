
using RabbitMQ.Client;
using WebChat.RabbitMQ;

namespace WebChat.Infrastructure.DI.RabbitMQ;

public static  class RegisterRabbitMQ
{
    public static IServiceCollection AddRegisterRabbitMQ(this IServiceCollection services, AppSettings appSettings)
    {
      
        services.AddSingleton<ConnectionFactory>(new ConnectionFactory
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
