namespace WebChat.Application.ApplicationSettings;

public interface IAppSettings
{
    string? AppEnvironment { get; }
    string? AllowToLogActions { get; }
    string? RequestAgentLimitCount { get; }
    string? ApiTimeConsumingToSlowLog { get; }
    string? SqlTimeConsumingToSlowLog { get; }
    string? Debug { get; }
    string? IsMasterService { get; }
    string? ClusterServiceNum { get; }
    string? DBProvider { get; }

    string? SqlConnectionString { get; }
    string? MongoConnectionString { get; }
    string? PostgresConnectionString { get; }
    string? MySqlConnectionString { get; }
    string? OracleConnectionString { get; }

    string? JwtSecretKey { get; }
    string? JwtIssuer { get; }
    string? JwtAudience { get; }
    string? JwtTokenTime { get; }
    string? UseSign { get; }
    string? TimestampSkew { get; }

    string? RedisConnectionString { get; }
    string? RedisCharRoomLimit { get; }

    string? RabbitMqHost { get; }
    string? RabbitMqUserName { get; }
    string? RabbitMqPassword { get; }
    string? ManagementApiUrl { get; }

    string? HealthCheckUI { get; }
    string? HealthCheckURL { get; }
}
