using Microsoft.AspNetCore.Mvc;
namespace WebChat.Infrastructure.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGlobalModelValidation(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}
