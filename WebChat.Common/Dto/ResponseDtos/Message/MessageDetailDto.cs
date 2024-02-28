using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace WebChat.Common.Dto.ResponseDtos.Message;

/// <summary>
/// MessageDetailDto
/// Developer: ALI RAZA MUSHTAQ
/// Date: 06-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class MessageDetailDto
{
    public long MessageId { get; set; }
    public long? UserId { get; set; }
    public string? UserName { get; set; }
    public string? NickName { get; set; }
    public string? UserPhoto { get; set; }
    public long? SubGroupId { get; set; }
    public string? SubGroupName { get; set; }
    public long? GroupId { get; set; }
    public string? GroupName { get; set; }
    public string? Message { get; set; }
    public DateTime? Time { get; set; }
    public string? UUID { get; set; }
}