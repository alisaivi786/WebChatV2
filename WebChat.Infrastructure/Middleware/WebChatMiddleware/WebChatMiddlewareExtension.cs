namespace WebChat.Infrastructure.Middleware.WebChatMiddleware;

public static class WebChatMiddlewareExtension
{
    public static IApplicationBuilder UseWebChatMiddleware(this IApplicationBuilder app)
    {
        app.UseSwaggerWithUI();
        //app.UseSerilogRequestLogging();
        // Migrate the database
        app.EnsureMigration();
        app.UseGlobalModelValidation();
        app.UseMiddleware<ExceptionMiddleware.ExceptionMiddleware>();
        //app.UseMiddleware<JwtTokenValidationMiddleware>();
        app.UseStaticFiles();
        // Add CookiePolicy
        // ...............
        app.UseRouting();
        #region App Use Cors
        app.UseCors(builder => builder
                .WithOrigins(
                "null",
                "http://localhost:8080",
                "https://localhost:5173",
                "https://localhost:5177",
                "http://localhost:8001",
                "https://localhost:5174",
                "https://webchat.22889.club",
                "http://localhost:90"
                )
                .AllowAnyHeader()
                .AllowAnyMethod().AllowCredentials());
        #endregion
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        });
       

        return app;

    }
        
    
}

    
