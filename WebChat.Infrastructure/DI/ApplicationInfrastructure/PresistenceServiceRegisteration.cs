#region NameSpace
namespace WebChat.Infrastructure.DI.ApplicationInfrastructure;
#endregion

#region PersistenceServiceRegistration
/// <summary>
/// Persistence Service Registration
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services, AppSettings applicationSettings)
    {
        var dbProvider = applicationSettings.DBProvider;
        var migrationAssembly = $"WebChat.Infrastructure.{dbProvider}";

        if (!string.IsNullOrEmpty(dbProvider) && dbProvider == "Mongo")
        {
            // Register Mongo DB Context
            services.AddMongoDbContext(applicationSettings.MongoConnectionString);
            // Register Mongo Repositories
            services.AddMongoRepositories();
        }
        else
        {
            // Register Context Switching Between Relational Database
            services.AddDbContext<WebchatDBContext>(options => _ = dbProvider switch
            {
                "SqlServer" => options.UseSqlServer(
                    applicationSettings.SqlConnectionString,
                    b =>
                    {
                        b.MigrationsAssembly(migrationAssembly);
                    }),

                "Npgsql" => options.UseNpgsql(
                    applicationSettings.PostgresConnectionString,
                    b =>
                    {
                        b.MigrationsAssembly(migrationAssembly);
                    }),

                "MySQL" => options.UseMySQL(
                    applicationSettings.MySqlConnectionString,
                    b => b.MigrationsAssembly(migrationAssembly)),

                "Oracle" => options.UseOracle(
                    applicationSettings.OracleConnectionString,
                    b => b.MigrationsAssembly(migrationAssembly)),

                _ => throw new InvalidOperationException($"Unsupported DBProvider: {dbProvider}")
            });

            services.AddScoped<IWebchatDBContext>(provider => provider.GetRequiredService<WebchatDBContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        return services;
    }
}

#endregion