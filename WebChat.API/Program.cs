

var builder = WebApplication.CreateBuilder(args);


// Load configuration
var configuration = builder.Configuration;

builder.Services.AddHttpContextAccessor();


var AppSetting = new AppSettings(configuration);

// Add AppSettings as a singleton service and pass the configuration to the constructor
builder.Services.AddSingleton(AppSetting);
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

app.UseCors(builder => builder
                    .WithOrigins("null","http://localhost:8080", "https://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod().AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsTest())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapHub<ChatHub>("/chatHub");
});

app.MapControllers();

app.Run();