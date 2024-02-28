namespace WebChat.Domain.Entities;

public class GroupUsersEntity : BaseEntity
{
    [ForeignKey("GroupId")]
    public long GroupId { get; set; }
    public virtual GroupEntity? Group { get; set; }
    [ForeignKey("SubGroupId")]
    public long SubGroupId { get; set; }
    public virtual SubGroupEntity? SubGroup { get; set; }
    public long UserId { get; set; }
}
