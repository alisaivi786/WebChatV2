namespace WebChat.Common.Dto.RequestDtos.Message;

public class UpdateMessageDto
{
    public long MessageId { get; set; }
    public long UserId { get; set; }
    public long GroupId { get; set; }
    public string? Message { get; set; }
    public DateTime UpdateTime { get; set; }
}
