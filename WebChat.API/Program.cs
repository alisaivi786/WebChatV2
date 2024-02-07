

using Microsoft.Extensions.DependencyInjection;
//using Asp.Net.Core.HealthCheck.ConfigureServices;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver.Core.Configuration;
using WebChat.Infrastructure.Health;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);


// Load configuration
var configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();


var AppSetting = new AppSettings(configuration);

// Add AppSettings as a singleton service and pass the configuration to the constructor
builder.Services.AddSingleton(AppSetting);
// Add Persistence Infrastructure
builder.Services.AddPersistenceInfrastructure(applicationSettings: AppSetting);

builder.Services.ApiVersionInfrastructure();


//Add Cors
builder.Services.AddCors();

// Add SignarR
builder.Services.AddSignalR();
//builder.Services.AddSingleton<ChatHub>();

// Add Rabbit MQ
builder.Services.AddRegisterRabbitMQ(AppSetting);

// Add Redis
builder.Services.AddRegisterRedis(AppSetting);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add Swagger Infrastructure
builder.Services.AddSwaggerWithVersioning();

// Add services to the container.
builder.Services.AddControllers();

// Add HealthCheck
builder.Services.AddHealthChecks()
    //.AddCheck<SqlHealthCheck>("SQL-Server", HealthStatus.Unhealthy)
    .AddMySql(AppSetting.MySqlConnectionString)
    .AddRedis(AppSetting.RedisConnectionString)
    .AddRabbitMQ(rabbitConnectionString: $"amqp://{AppSetting.RabbitMqUserName}:{AppSetting.RabbitMqPassword}@{AppSetting.RabbitMqHost}:5672/")
    ;

builder.Services.AddHealthChecksUI()
    .AddInMemoryStorage();

var app = builder.Build();

// Migrate the database
app.EnsureMigration();

app.UseCors(builder => builder
                    .WithOrigins("null","http://localhost:8080", "https://localhost:5173", "https://localhost:5177")
                    .AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsTest())
{
    app.UseSwaggerWithUI();
}


app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
});

app.MapHealthChecksUI();


app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapHub<ChatHub>("/chatHub");
});

app.MapControllers();

app.Run();