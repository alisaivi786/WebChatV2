var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddWebChatService(configuration);
builder.Services.AddControllers();
var app = builder.Build();
app.UseWebChatMiddleware();
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapHub<ChatHub>("/chatHub");
});
app.MapHealthChecksUI();
app.MapControllers();
app.Run();