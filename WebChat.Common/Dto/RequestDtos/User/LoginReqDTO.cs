namespace WebChat.Common.Dto.RequestDtos.User;

public class LoginReqDTO
{
    public string? UserName { get; set; }
    public string? UserId { get; set; }
    public string? Password { get; set; }
    public long GroupId { get; set; }
    public long SubGroupId { get; set; }
}
