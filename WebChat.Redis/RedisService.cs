
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;
using WebChat.Common.Dto.RequestDtos.Message;
using WebChat.Common.Dto.ResponseDtos.Message;

namespace WebChat.Redis;

public class RedisService : IRedisService
{
    private const string redisConnection = "localhost:6379";

    #region PushMessageToRedisAsync
    public void PushMessageToRedisAsync(string message, string roomId)
    {
        //  ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("47.91.115.74:6379,abortConnect=false,connectTimeout=5000,connectRetry=3,syncTimeout=2000"); //must change to read from appsettings file
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnection); //must change to read from appsettings file

        IDatabase db = redis.GetDatabase(15);

        string chatRoomKey = $"chatroom:{roomId}";

       // string jsonMessage = JsonConvert.SerializeObject(message);

        SendMessage(db, chatRoomKey, "message", message);

        RetrieveDisplayAndTrimMessages(db, chatRoomKey, 100);

        redis.Close();
    }
    #endregion

    #region RetrieveDisplayAndTrimMessages
    private void RetrieveDisplayAndTrimMessages(IDatabase db, string chatRoomKey, int messageCountToKeep)
    {
        RedisValue[] messages = db.ListRange(chatRoomKey);

        db.ListTrim(chatRoomKey, -messageCountToKeep, -1);
    }
    #endregion

    #region SendMessage
    static void SendMessage(IDatabase db, string chatRoomKey, string userName, string message)
    {
        long messageId = db.ListLength(chatRoomKey) + 1;

        string formattedMessage = $"{message}";

        db.ListRightPush(chatRoomKey, formattedMessage);

        Console.WriteLine($"Message sent by {userName}: {message}");
    }
    #endregion

    public async Task<List<MessageDetailDto>> GetAllRecords(int roomId)
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnection); //must change to read from appsettings file

        IDatabase db = redis.GetDatabase(15);

        var key = $"chatroom:{roomId}";
        var records = await db.ListRangeAsync(key);

        // return records.Select(r => JsonConvert.DeserializeObject<MessageDetailDto>(r.ToString())).ToList();

        var x = records.Select(r =>
        {
            // Remove the outer quotes and then deserialize the inner JSON
            var innerJson = r.ToString().Trim('"');

            // Deserialize the inner JSON
            var messageDetailDto = JsonConvert.DeserializeObject<MessageDetailDto>(innerJson);

            return messageDetailDto;
        }).ToList();

        return x;
    }
}
