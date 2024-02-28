namespace WebChat.Common.Dto.RequestDtos.SubGroup;

/// <summary>
/// Add Sub Group Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 23-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class AddSubGroupReqDto : ApiRequest
{
    public string? Name { get; set; }
    public long GroupId { get; set; }
}
