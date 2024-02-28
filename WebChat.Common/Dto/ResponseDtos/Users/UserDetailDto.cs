namespace WebChat.Common.Dto.ResponseDtos.Users;

public class UserDetailDto
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public Guid? RowId { get; set; }
    public string? UserName { get; set; }
    public string? NickName { get; set; }
    public string? UserPhoto { get; set; }
}
