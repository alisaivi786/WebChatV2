using System.Configuration;
using WebChat.Application.Auth;

namespace WebChat.Infrastructure.Services.WebChatExtension;

public static class WebChatServiceExtension
{
    #region WebChatServiceExtension
    #region WebChatServiceExtension Summary
    /// <summary>
    /// WebChatServiceExtension
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 21-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="services"></param>
    #endregion
    public static IServiceCollection AddWebChatService(this IServiceCollection services, IConfiguration configuration)
    {
        #region ...

        services.AddHttpContextAccessor();

        // Add Auth Registration Service
        services.AuthService();

        //Add Serilog
        //builder.Host.UseSerilog((context, configuration) =>
        //    configuration.ReadFrom.Configuration(context.Configuration)
        //                .WriteTo.Console()
        //                .WriteTo.Seq("http://localhost:5341"));

        // Add services to the container, including ILogger
        services.AddLogging();
        var AppSetting = new AppSettings(configuration);
        // Add AppSettings as a singleton service and pass the configuration to the constructor
        services.AddSingleton<IAppSettings>(AppSetting);

        // Add Redis
        services.AddRegisterRedis();

        // Add Persistence Infrastructure
        services.AddPersistenceInfrastructure(applicationSettings: AppSetting);
        // Jwt Infrastructure
        services.AddJWTInfrastructure(AppSetting);

        // Global Model Validation
        services.AddGlobalModelValidation();

        services.ApiVersionInfrastructure();
        //Add Cors
        services.AddCors();
        // Add SignarR
        services.AddSignalR();
        // Add Rabbit MQ
        services.AddRegisterRabbitMQ(AppSetting);
      
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        // Add Swagger Infrastructure
        services.AddSwaggerWithVersioning();
        // Add HealthCheck
        services.AddHealthChecks()
            .AddCheck<SqlHealthCheck>("sqlServer", HealthStatus.Unhealthy)
            .AddMySql(AppSetting.MySqlConnectionString)
            .AddRedis(AppSetting.RedisConnectionString)
            .AddRabbitMQ(rabbitConnectionString: $"amqp://{AppSetting.RabbitMqUserName}:{AppSetting.RabbitMqPassword}@{AppSetting.RabbitMqHost}:5672/");
        services.AddHealthChecksUI()
            .AddInMemoryStorage();

        #region Return Service
        return services;
        #endregion 
        #endregion
    }
    #endregion
}
