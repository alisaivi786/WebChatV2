namespace WebChat.Infrastructure.Services.ApplicationInfrastructure;

/// <summary>
/// Register Mongo Database
/// Developer: ALI RAZA MUSHTAQ
/// Date: 31-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
public static class RegisterMongoDatabase
{
    public static IServiceCollection AddMongoDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
        services.AddScoped(provider =>
        {
            var client = provider.GetRequiredService<IMongoClient>();
            return client.GetDatabase("WebChatV2");
        });

        // Add other MongoDB-related services as needed

        return services;
    }
}
