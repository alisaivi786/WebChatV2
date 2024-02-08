namespace WebChat.Common.Dto.RequestDtos.GroupUser;


/// <summary>
/// Add Group User Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 06-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class AddGroupUserReqDto : ApiRequest
{
    public long UserId { get; set; }
    public long GroupId { get; set; }
}