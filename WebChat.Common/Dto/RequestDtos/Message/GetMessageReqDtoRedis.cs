
using WebChat.Common.IBaseRequest;

namespace WebChat.Common.Dto.RequestDtos.Message;

public class GetMessageReqDtoRedis : PageBaseRequest
{
    public int GroupId { get; set; }
}
