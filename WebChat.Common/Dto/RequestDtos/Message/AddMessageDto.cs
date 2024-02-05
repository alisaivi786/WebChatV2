namespace WebChat.Common.Dto.RequestDtos.Message;

public class AddMessageDto
{
    public long UserId { get; set; }
    public long GroupId { get; set; }
    public string? Message { get; set; }
    public DateTime SetTime { get; set; }
}
