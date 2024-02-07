using Newtonsoft.Json;

namespace WebChat.Common.Dto.ResponseDtos.Health;

public class HealthRspDto
{
    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("totalDuration")]
    public TimeSpan? TotalDuration { get; set; }

    [JsonProperty("entries")]
    public Dictionary<string, HealthModel>? Entries { get; set; }
}
