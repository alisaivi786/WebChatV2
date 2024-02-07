namespace WebChat.Infrastructure.Middleware.EnsureMigrationExtension;

public static class MigrationExtensions
{
    public static IApplicationBuilder EnsureMigration(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var dbContext = services.GetRequiredService<WebchatDBContext>(); // Replace with your actual DbContext type
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<WebchatDBContext>>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
        return app;
    }
}