
namespace WebChat.Redis;

public interface IRedisService
{
    public void PushMessageToRedisAsync(string message, string roomId);
}
