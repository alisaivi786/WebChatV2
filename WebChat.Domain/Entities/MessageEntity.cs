using System.ComponentModel.DataAnnotations.Schema;

namespace WebChat.Domain.Entities;

public class MessageEntity: BaseEntity
{
    public string? Content { get; set; }
    public DateTime SentTime { get; set; } = DateTime.Now;
    [ForeignKey("SubGroupId")]
    public long SubGroupId { get; set; }
    public virtual SubGroupEntity? SubGroup { get; set; }
    public long UserId { get; set; }
    public string? UUID { get; set; }


}
