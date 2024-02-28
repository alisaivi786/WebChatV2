namespace WebChat.Common.Dto.RequestDtos.GroupUser;

/// <summary>
/// Get Group User Request Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 08-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class GetGroupUserReqDto : PageBaseRequest
{
    //Filter Properties
    public long? UserId { get; set; }
    public long? GroupId { get; set; }
    public long? SubGroupId { get; set; }
}
