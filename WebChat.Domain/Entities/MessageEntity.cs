using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Domain.Entities;

public class MessageEntity: BaseEntity
{
    public string? Content { get; set; }
    public DateTime SentTime { get; set; }

    [ForeignKey("GroupId")]
    public long GroupId { get; set; }
    public virtual GroupEntitiy? Group { get; set; }

    [ForeignKey("UserId")]
    public long UserId { get; set; }
    public virtual UserEntity? User { get; set; }

    
}
