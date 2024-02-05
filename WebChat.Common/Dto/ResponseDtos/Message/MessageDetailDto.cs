namespace WebChat.Common.Dto.ResponseDtos.Message;

public class MessageDetailDto
{
    public long MessageId { get; set; }
    public long? UserId { get; set; }
    public long? GroupId { get; set; }
    public string? Message { get; set; }
    public DateTime? Time { get; set; }
}
