using Microsoft.EntityFrameworkCore;
using System.Threading;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Extension.Extensions;
using WebChat.Hubs;
using WebChat.Infrastructure.DI.ApplicationInfrastructure;
using WebChat.Infrastructure.DI.RabbitMQ;
using WebChat.Infrastructure.DI.Redis;
using WebChat.Presistence.DBContext;
using WebChat.Presistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


// Load configuration
var configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();


var AppSetting = new AppSettings(configuration);

// Add AppSettings as a singleton service and pass the configuration to the constructor
builder.Services.AddSingleton(_ => AppSetting);
// Add Persistence Infrastructure
builder.Services.AddPersistenceInfrastructure(applicationSettings: AppSetting);

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
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddControllers();
var app = builder.Build();

// Migrate the database
app.EnsureMigration();

app.UseRouting();

app.UseCors(builder => builder
                    .WithOrigins("null")
                    .AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials());

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<WebChat.Hubs.ChatHub>("/chatHub");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsTest())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();