namespace WebChat.Common.Dto.RequestDtos.SubGroup;

/// <summary>
/// Update Sub Group
/// Developer: ALI RAZA MUSHTAQ
/// Date: 23-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class UpdateSubGroupReqDto : ApiRequest
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public long GroupId { get; set; }
}
