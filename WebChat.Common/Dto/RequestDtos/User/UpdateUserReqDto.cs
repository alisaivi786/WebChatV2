namespace WebChat.Common.Dto.RequestDtos.User;

public class UpdateUserReqDto : ApiRequest
{
    public Guid RowId { get; set; }
    public string? UserName { get; set; }
    public string? NickName { get; set; }
    public string? UserPhoto { get; set; }
}
