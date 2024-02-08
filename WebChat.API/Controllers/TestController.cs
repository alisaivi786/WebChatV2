using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace WebChat.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [MapToApiVersion(1)]
        [HttpPost("ChatHubTest")]
        [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
        public async Task<IActionResult> ChatHubTest()
        {
            const int numberOfRecords = 1;

            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7285/chatHub")
                .Build();

            await hubConnection.StartAsync();

            // Run the test
            for (int i = 0; i < numberOfRecords; i++)
            {
                var message = GetTestMessage(); // Implement this method to generate your test message
                await hubConnection.InvokeAsync("SendMessageAsync", message);

                await Task.Delay(200);
            }

            await hubConnection.StopAsync();

            return Ok();
        }

        private string GetTestMessage()
        {
            return JsonConvert.SerializeObject(new { GroupId = 1, GroupName = "TB-Admin", UserId = 3, UserName = "Aymen", Message = "TestMessage", TimeUTC = DateTime.UtcNow });
        }
    }
}