using Newtonsoft.Json;
using WebChat.Common.Dto.ResponseDtos.Health;

namespace WebChat.API.Controllers.Health
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/Health")]
    [ApiController]
    public class HealthCheckController(IAppSettings _appSettings) : ControllerBase
    {
        private readonly IAppSettings appSettings = _appSettings;

        [HttpGet("status")]
        public async Task<IActionResult> Get()
        {
            using HttpClient httpClient = new();
            HttpResponseMessage response = await httpClient.GetAsync($"{appSettings.HealthCheckURL}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                HealthRspDto? healthResponse = JsonConvert.DeserializeObject<HealthRspDto>(responseBody);
                return Ok(healthResponse);
            }
            return BadRequest(response.ReasonPhrase);
        }
    }
}
