
using StackExchange.Redis;
using WebChat.Common.Dto.ResponseDtos.Message;

namespace WebChat.Redis;

public interface IRedisService
{
    public void PushMessageToRedisAsync(string message, string roomId);
    public Task<List<MessageDetailDto>> GetAllRecords(int roomId);
}
