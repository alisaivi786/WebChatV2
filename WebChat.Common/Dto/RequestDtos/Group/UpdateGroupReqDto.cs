namespace WebChat.Common.Dto.RequestDtos.Group;

/// <summary>
/// Update Group
/// Developer: ALI RAZA MUSHTAQ
/// Date: 06-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class UpdateGroupReqDto : ApiRequest
{
    public long GroupId { get; set; }
    public string? Name { get; set; }
}
