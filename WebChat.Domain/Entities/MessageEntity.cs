namespace WebChat.Domain.Entities;

public class MessageEntity: BaseEntity
{
    public string? Content { get; set; }
    public DateTime SentTime { get; set; }
}
