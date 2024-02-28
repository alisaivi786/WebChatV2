using WebChat.Infrastructure.Middleware.ModelValidation;

namespace WebChat.Infrastructure.Services.ModelValidation;

public static class ModelValidationMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalModelValidation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ModelValidationMiddleware>();
    }
}