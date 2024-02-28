namespace WebChat.Common.Dto.RequestDtos.GroupUser;

/// <summary>
/// Get Delete Group User Request Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 08-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class DeleteGroupUserReqDto : ApiRequest
{
    public long? Id { get; set; }
    public long? UserId { get; set; }
}