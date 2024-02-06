using WebChat.Common.IBaseRequest;

namespace WebChat.Common.Dto.RequestDtos.Group;

/// <summary>
/// Delete Group DTO
/// Developer: ALI RAZA MUSHTAQ
/// Date: 06-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public class DeleteGroupReqDto : ApiRequest
{
    public long Id { get; set; }
}
