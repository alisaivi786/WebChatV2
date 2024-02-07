namespace WebChat.Infrastructure.Services.ApplicationInfrastructure;

/// <summary>
/// Register Mongo Repositories
/// Developer: ALI RAZA MUSHTAQ
/// Date: 31-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
public static class RegisterMongoRepositories
{
    public static IServiceCollection AddMongoRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMongoUserRepository, MongoUserRepository>();

        // Add other MongoDB-related services as needed

        return services;
    }
}
