using Microsoft.Extensions.Diagnostics.HealthChecks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace WebChat.Infrastructure.Health;

public class MySqlHealthCheck(AppSettings appSettings) : IHealthCheck
{
    private readonly AppSettings AppSettings = appSettings;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var mySqlConnection = new MySqlConnection(AppSettings.MySqlConnectionString);

            await mySqlConnection.OpenAsync(cancellationToken);

            using var command = mySqlConnection.CreateCommand();
            command.CommandText = "SELECT 1";

            await command.ExecuteScalarAsync(cancellationToken);

            return HealthCheckResult.Healthy();

        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy(
                context.Registration.FailureStatus.ToString(),
                exception: ex);
        }
    }
}