using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Infrastructure.DI.ApplicationInfrastructure;
using WebChat.Presistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


// Load configuration
var configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();


var AppSetting = new AppSettings(configuration);

// Add AppSettings as a singleton service and pass the configuration to the constructor
builder.Services.AddSingleton(_ => AppSetting);
// Add Persistence Infrastructure
builder.Services.AddPersistenceInfrastructure(applicationSettings:AppSetting);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddControllers();
var app = builder.Build();

//app.UseRequestLocalization(new RequestLocalizationOptions
//{
//    DefaultRequestCulture = new RequestCulture("en-US"),
//    SupportedCultures = supportedCultures,
//    SupportedUICultures = supportedCultures
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();