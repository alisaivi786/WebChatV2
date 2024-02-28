
using WebChat.Common.IBaseRequest;

namespace WebChat.Common.Dto.RequestDtos.Message;

public class GetMessageReqDtoRedis : PageBaseRequest
{
    public string GroupName { get; set; } = string.Empty;
    public int SubGroupId { get; set; }
}
