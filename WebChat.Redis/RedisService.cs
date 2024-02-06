
using Newtonsoft.Json;
using StackExchange.Redis;

namespace WebChat.Redis;

public class RedisService : IRedisService
{
    #region PushMessageToRedisAsync
    public void PushMessageToRedisAsync(string message, string roomId)
    {
        // Connection to the Redis server
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("47.91.115.74:6379"); //must change to read from appsettings file

        // Get a reference to the database
        IDatabase db = redis.GetDatabase(15);

        // For simplicity, let's use a single chat room with a key "chatroom"
        string chatRoomKey = $"chatroom:{roomId}";

        // Convert Message object to JSON string
        string jsonMessage = JsonConvert.SerializeObject(message);

        // Simulate two users sending messages to the chat room
        SendMessage(db, chatRoomKey, "message", jsonMessage);

        // Retrieve, display, and trim the list to keep only the latest 100 messages
        //RetrieveDisplayAndTrimMessages(db, chatRoomKey, 100);
        RetrieveDisplayAndTrimMessages(db, chatRoomKey, 10);

        // Close the Redis connection
        redis.Close();
    }
    #endregion

    #region RetrieveDisplayAndTrimMessages
    private void RetrieveDisplayAndTrimMessages(IDatabase db, string chatRoomKey, int messageCountToKeep)
    {
        // Retrieve all messages from the Redis list
        RedisValue[] messages = db.ListRange(chatRoomKey);

        // Display the messages (you can modify this part based on your needs)
        foreach (var message in messages)
        {
            Console.WriteLine($"Message: {message}");
        }

        // Trim the list to keep only the latest 100 messages
        db.ListTrim(chatRoomKey, -messageCountToKeep, -1);
    }
    #endregion

    #region SendMessage
    static void SendMessage(IDatabase db, string chatRoomKey, string userName, string message)
    {
        // Create a unique message ID
        long messageId = db.ListLength(chatRoomKey) + 1;

        // Format the message with user name and content
        string formattedMessage = $"{userName}: {message}";

        // Add the message to the Redis list
        db.ListRightPush(chatRoomKey, formattedMessage);

        Console.WriteLine($"Message sent by {userName}: {message}");
    }
    #endregion

    #region RetrieveAndDisplayMessages
    static void RetrieveAndDisplayMessages(IDatabase db, string chatRoomKey)
    {
        // Retrieve all messages from the Redis list
        var messages = db.ListRange(chatRoomKey);

        Console.WriteLine("Chat Room Messages:");

        // Display each message
        foreach (var message in messages)
        {
            Console.WriteLine(message);
        }
    }
    #endregion
}
