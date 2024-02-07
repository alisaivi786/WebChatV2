using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.SqlClient;
namespace WebChat.Infrastructure.Health;

public class SqlHealthCheck(AppSettings appSettings) : IHealthCheck
{
    private readonly AppSettings AppSettings = appSettings;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var sqlConnection = new SqlConnection(AppSettings.SqlConnectionString);

            await sqlConnection.OpenAsync(cancellationToken);

            using var command = sqlConnection.CreateCommand();
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