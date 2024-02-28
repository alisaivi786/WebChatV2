namespace WebChat.Domain.Entities;

public class SubGroupEntity : BaseEntity
{
    public string? Name { get; set; }

    [ForeignKey("GroupId")]
    public long GroupId { get; set; }
    public virtual GroupEntity? Group { get; set; }
}
