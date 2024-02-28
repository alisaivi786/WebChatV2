namespace WebChat.Common.Dto.ResponseDtos.Users;

public record AddUserDto
{
    public long UserId { get; set; }
    public string? UserName { get; set; }
    public string? NickName { get; set; }
    public string? Photo { get; set; }
}
