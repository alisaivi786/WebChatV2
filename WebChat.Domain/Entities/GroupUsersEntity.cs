namespace WebChat.Domain.Entities;

public class GroupUsersEntity : BaseEntity
{
    public int GroupId { get; set; }
    public int UserId { get; set; }
}
