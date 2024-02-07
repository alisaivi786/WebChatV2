using Microsoft.Extensions.Configuration;

namespace WebChat.Application.ApplicationSettings;

/// <summary>
/// Mapp all Appjson File with Concreate Object
/// Developer: ALI RAZA MUSHTAQ
/// Date: 30-Jan-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="configuration"></param>
public class AppSettings(IConfiguration configuration)
{
    public string? AppEnvironment { get; set; } = configuration["AppInfo:AppEnvironment"];

    #region System Settings

    public string? AllowToLogActions { get; set; } = configuration["SystemConfig:Sql"];
    public string? RequestAgentLimitCount { get; set; } = configuration["SystemConfig:RequestLimitCount"];
    public string? ApiTimeConsumingToSlowLog { get; set; } = configuration["SystemConfig:ApiTimeConsumingToSlowLog"];
    public string? SqlTimeConsumingToSlowLog { get; set; } = configuration["SystemConfig:SqlTimeConsumingToSlowLog"];
    public string? Debug { get; set; } = configuration["SystemConfig:Debug"];
    public string? IsMasterService { get; set; } = configuration["SystemConfig:IsMasterService"];
    public string? ClusterServiceNum { get; set; } = configuration["SystemConfig:ClusterServiceNum"];
    public string? DBProvider { get; set; } = configuration["SystemConfig:DBProvider"];
    #endregion

    #region Database Settings
    public string? SqlConnectionString { get; set; } = configuration["ConnectionStrings:SqlServer"];
    public string? MongoConnectionString { get; set; } = configuration["ConnectionStrings:Mongo"];
    public string? PostgresConnectionString { get; set; } = configuration["ConnectionStrings:Postgres"];
    public string? MySqlConnectionString { get; set; } = configuration["ConnectionStrings:MySql"];
    public string? OracleConnectionString { get; set; } = configuration["ConnectionStrings:Oracle"];
    #endregion

    #region JWT Token Settings
    public string? JwtSecretKey { get; set; } = configuration["Jwt:SecretKey"];
    public string? JwtIssuer { get; set; } = configuration["Jwt:Issuer"];
    public string? JwtAudience { get; set; } = configuration["Jwt:Audience"];
    public string? JwtTokenTime { get; set; } = configuration["Jwt:TokenTime"];
    public string? UseSign { get; set; } = configuration["Signature:UseSign"];
    public string? TimestampSkew { get; set; } = configuration["Signature:TimestampSkew"];
    #endregion

    #region Redis Settings
    public string? RedisConnectionString { get; set; } = configuration["Redis:ConnectionString"];
    #endregion

    #region RabbitMQ Setting
    public string? RabbitMqHost { get; set; } = configuration["RabbitMq:Host"];
    public string? RabbitMqUserName { get; set; } = configuration["RabbitMq:UserName"];
    public string? RabbitMqPassword { get; set; } = configuration["RabbitMq:Password"];
    #endregion

    #region HealthCheck
    public string? HealthCheckUI { get; set; } = configuration["HealthChecksUI:CustomHealth:HealthCheckUI"];
    public string? HealthCheckURL { get; set; } = configuration["HealthChecksUI:CustomHealth:HealthCheckURL"]; 
    #endregion
}
