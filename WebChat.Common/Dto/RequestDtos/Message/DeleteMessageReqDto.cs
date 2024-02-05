using WebChat.Common.IBaseRequest;

namespace WebChat.Common.Dto.RequestDtos.Message;

public class DeleteMessageReqDto : ApiRequest
{
    public long Id { get; set; }
}
