namespace WebChat.Common.Dto.ResponseDtos.LotteryUsers;

public class GetuserDetailsRspDto
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserPhoto { get; set; }
    public string? NickName { get; set; }
    public string? RowId { get; set; } = Guid.NewGuid().ToString();
}
