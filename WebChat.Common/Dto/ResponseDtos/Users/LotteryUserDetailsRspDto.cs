namespace WebChat.Common.Dto.ResponseDtos.Users;

public class LotteryUserDetailsRspDto
{
    public long UserId { get; init; }
    public string? UserName { get; init; }
    public string? NickName { get; init; }
    public string? UserPhoto { get; init; }
    public string? Password { get; set; }
}
