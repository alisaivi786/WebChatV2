using Newtonsoft.Json;
namespace WebChat.Common.Dto.ResponseDtos.Health;

public class HealthModel
{
    [JsonProperty("data")]
    public object? Data { get; set; }

    [JsonProperty("duration")]
    public TimeSpan? Duration { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }
}
