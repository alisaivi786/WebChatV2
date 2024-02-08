namespace WebChat.Common.Dto.RequestDtos.Message;

/// <summary>
/// Add Message Req Dto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 06-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class AddMessageReqDto : ApiRequest
{
    public long UserId { get; set; }
    public long GroupId { get; set; }
    public string? Message { get; set; }
    public DateTime SetTime { get; set; }
}
