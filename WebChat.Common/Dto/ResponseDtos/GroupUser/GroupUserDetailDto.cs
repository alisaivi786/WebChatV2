namespace WebChat.Common.Dto.ResponseDtos.GroupUser;

public class GroupUserDetailDto
{
    public long? GroupUserId { get; set; }
    public long? GroupId { get; set; }
    public string? GroupName { get; set; }
    public long? UserId { get; set; }
    public string? UserName { get; set; }
}
