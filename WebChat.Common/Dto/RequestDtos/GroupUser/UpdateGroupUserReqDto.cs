namespace WebChat.Common.Dto.RequestDtos.GroupUser;

/// <summary>
/// Get Update Group User Request Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 08-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class UpdateGroupUserReqDto : ApiRequest
{
    public long GroupUserId { get; set; }
    public long UserId { get; set; }
    public long GroupId { get; set; }
}
