namespace WebChat.Common.Dto.ResponseDtos.SubGroup;

#region Group Details Rsp Summary
/// <summary>
/// Sub Group Details Response
/// Developer: ALI RAZA MUSHTAQ
/// Date: 23-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public class SubGroupDetailRspDto
{
    public long? SubGroupId { get; set; }
    public string? SubGroupName { get; set; }
    public long? GroupId { get; set; }
    public string? GroupName { get; set; }
}
