namespace WebChat.Domain.Entities;

public class GroupUsersEntity : BaseEntity
{
    [ForeignKey("GroupId")]
    public long GroupId { get; set; }
    public virtual GroupEntitiy? Group { get; set; }

    [ForeignKey("UserId")]
    public long UserId { get; set; }
    public virtual UserEntity? User { get; set; }
}
