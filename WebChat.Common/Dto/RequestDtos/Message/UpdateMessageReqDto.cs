namespace WebChat.Common.Dto.RequestDtos.Message;

/// <summary>
/// Get Update Message Request Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 07-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class UpdateMessageReqDto : ApiRequest
{
    public long MessageId { get; set; }
    public long UserId { get; set; }
    public long GroupId { get; set; }
    public string? Message { get; set; }
    public DateTime UpdateTime { get; set; }
}
