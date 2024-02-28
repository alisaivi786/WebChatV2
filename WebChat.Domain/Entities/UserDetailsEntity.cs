namespace WebChat.Domain.Entities;

public class UserDetailsEntity : BaseEntity
{
    public int? UserId { get; set; }
    public string? UserName { get; set; }
    public string? NickName { get; set; }
    public string? UserPhoto { get; set; }
    public DateTime? UtcLastLoginTime { get; set; } = DateTime.UtcNow;

}
