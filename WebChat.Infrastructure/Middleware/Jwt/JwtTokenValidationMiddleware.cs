using JwtService;
using JwtService.Interface;
using WebChat.Extension.Extensions;

namespace WebChat.Infrastructure.Middleware.Jwt;

public class JwtTokenValidationMiddleware(RequestDelegate next, IAppSettings AppSettings,IAuthService authService)
{
    private readonly RequestDelegate _next = next;
    private readonly IAppSettings AppSettings = AppSettings;
    private readonly IAuthService AuthService = authService;

    public async Task InvokeAsync(HttpContext context)
    {

        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Replace("Bearer ", "");



        // Check if the request is for the login endpoint
        if (context.Request.Path.StartsWithSegments("/api/v1/Auth/AccessToken")
            || context.Request.Path.StartsWithSegments("/api/auth/get-token")
            || context.Request.Path.StartsWithSegments("/api/auth/token-auhtenticated")
            )
        {
            // Allow anonymous access to the login endpoint
            await _next(context);
            return;
        }

        var tokenValidate = AuthService.ValidateJwtToken(token);

        if (!tokenValidate)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await _next(context);
    }
}
