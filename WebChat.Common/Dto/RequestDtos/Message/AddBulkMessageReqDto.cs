namespace WebChat.Common.Dto.RequestDtos.Message;

/// <summary>
/// Add Bulk Message Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 07-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class AddBulkMessageReqDto
{
    public long UserId { get; set; }
    public long GroupId { get; set; }
    public string? Content { get; set; }
    public DateTime SetTime { get; set; }
}
