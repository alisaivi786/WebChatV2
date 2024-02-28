namespace WebChat.Domain.Entities;

public class LoginInUserEntity : BaseEntity
{
    public int UserId { get; set; }
    public DateTime? UtcLastLoginTime { get; set; }
}
