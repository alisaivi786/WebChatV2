
using Newtonsoft.Json;
using StackExchange.Redis;
using WebChat.Application.ApplicationSettings;
using WebChat.Common.Dto.ResponseDtos.LotteryUsers;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.Common.Dto.ResponseDtos.Users;

namespace WebChat.Redis;

/// <summary>
/// RedisService Class
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 05-02-2024
/// </summary>
public class RedisService : IRedisService
{
    #region private fields
    private readonly IConnectionMultiplexer redis;
    private readonly IDatabase db;
    private readonly string redisConnection;
    private readonly int chatRoomLimit = 1000;
    #endregion

    #region Constructor Initialization
    /// <summary>
    /// RedisService Constructor
    /// </summary>
    /// <param name="appSetting"></param>
    /// <returns></returns>
    public RedisService(IConnectionMultiplexer redis, IAppSettings appSetting)
    {
        this.redis = redis;
        db = redis.GetDatabase();
        redisConnection = appSetting.RedisConnectionString;
        chatRoomLimit = Convert.ToInt32(appSetting.RedisCharRoomLimit);
    }
    #endregion


    #region Message Management

    #region PushMessageToRedisAsync
    /// <summary>
    /// PushMessageToRedisAsync
    /// </summary>
    /// <param name="message"></param>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public void PushMessageToRedisAsync(string message, string roomId)
    {
        string chatRoomKey = string.Format(CommonCacheKey.chatroom, roomId);

        PushJsonObject(db, chatRoomKey, message);

        RetrieveDisplayAndTrimMessages(db, chatRoomKey, chatRoomLimit);
    }
    #endregion

    #region RetrieveDisplayAndTrimMessages
    /// <summary>
    /// RetrieveDisplayAndTrimMessages
    /// </summary>
    /// <param name="db"></param>
    /// <param name="chatRoomKey"></param>
    /// <param name="messageCountToKeep"></param>
    /// <returns></returns>
    private static void RetrieveDisplayAndTrimMessages(IDatabase db, string chatRoomKey, int messageCountToKeep)
    {
        RedisValue[] messages = db.ListRange(chatRoomKey);
        db.ListTrim(chatRoomKey, -messageCountToKeep, -1);
    }
    #endregion

    #region GetAllRedisMessages
    /// <summary>
    /// GetAllRedisMessages
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public async Task<List<MessageDetailDto>> GetAllRedisMessages(string roomId)
    {
        var key = string.Format(CommonCacheKey.chatroom, roomId);

        var records = await db.ListRangeAsync(key);

        var messageDetailDtos = new List<MessageDetailDto>();

        foreach (var r in records)
        {
            using (JsonTextReader reader = new JsonTextReader(new StringReader(r.ToString())))
            {
                JsonSerializer serializer = new JsonSerializer();
                var messageDetailDto = serializer.Deserialize<MessageDetailDto>(reader);
                messageDetailDtos.Add(messageDetailDto);
            }
        }

        var mappedMessageDetails = await MapUsersDetailsList(messageDetailDtos);
        //  var mappedMessageDetails = messageDetailDtos;

        return mappedMessageDetails;
    }
    #endregion

    #region GetRedisCount
    /// <summary>
    /// GetRedisCount
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns>long</returns>
    public async Task<long> GetRedisCount(string roomId)
    {
        var key = string.Format(CommonCacheKey.chatroom, roomId);

        var messagesCount = await db.ListLengthAsync(key);

        return messagesCount;
    }
    #endregion

    #region GetLastMessageUUID
    /// <summary>
    /// GetLastMessageUUID
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns>string</returns>
    public async Task<string> GetLastMessageUUID(string roomId)
    {
        var key = string.Format(CommonCacheKey.chatroom, roomId);
        var records = await db.ListRangeAsync(key);

        var messageDetailDtos = new List<MessageDetailDto>();

        foreach (var r in records)
        {
            using (JsonTextReader reader = new JsonTextReader(new StringReader(r.ToString())))
            {
                JsonSerializer serializer = new JsonSerializer();
                var messageDetailDto = serializer.Deserialize<MessageDetailDto>(reader);
                messageDetailDtos.Add(messageDetailDto);
            }
        }

        var lastUUID = messageDetailDtos//.OrderByDescending(x=>x.Time)
            .Select(x => x.UUID).FirstOrDefault();

        return lastUUID ?? "";
    }
    #endregion

    #endregion

    #region User Management

    #region GetAllUsersDetails
    /// <summary>
    /// GetLastMessageUUID
    /// </summary>
    /// <returns>Task<List<GetuserDetailsRspDto>></returns>
    public async Task<List<GetuserDetailsRspDto>> GetAllUsersDetails()
    {
        var key = CommonCacheKey.cacheKey_users_usersdetails;

        var records = await db.ListRangeAsync(key);

        var userDetailDto = new List<GetuserDetailsRspDto>();

        foreach (var r in records)
        {
            using (JsonTextReader reader = new JsonTextReader(new StringReader(r.ToString())))
            {
                JsonSerializer serializer = new JsonSerializer();
                var messageDetail = serializer.Deserialize<GetuserDetailsRspDto>(reader);
                userDetailDto.Add(messageDetail);
            }
        }

        return userDetailDto;
    }

    public async Task<List<GetuserDetailsRspDto>> GetAllUsersDetails2()
    {
        var key = CommonCacheKey.cacheKey_users_usersdetails;

        var records = await db.StringGetAsync(key);

        var userDetailDto = new List<GetuserDetailsRspDto>();

        using (JsonTextReader reader = new JsonTextReader(new StringReader(records.ToString())))
        {
            JsonSerializer serializer = new JsonSerializer();
            userDetailDto = serializer.Deserialize<List<GetuserDetailsRspDto>>(reader);
        }
        return userDetailDto;
    }
    #endregion

    #region GetUserDetailsAsync
    /// <summary>
    /// GetUserDetailsAsync
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns>Task<GetuserDetailsRspDto></returns>
    public async Task<GetuserDetailsRspDto> GetUserDetailsAsync(long UserId)
    {
        RedisValue[] records;

        var key = CommonCacheKey.cacheKey_users_usersdetails;

        records = await db.ListRangeAsync(key);

        var userDetailDto = new List<GetuserDetailsRspDto>();

        foreach (var r in records)
        {
            using (JsonTextReader reader = new JsonTextReader(new StringReader(r.ToString())))
            {
                JsonSerializer serializer = new JsonSerializer();
                var messageDetail = serializer.Deserialize<GetuserDetailsRspDto>(reader);
                userDetailDto.Add(messageDetail);
            }
        }

        var user = userDetailDto.Where(x => x.UserId == UserId).FirstOrDefault();

        return user ?? new GetuserDetailsRspDto();
    }

    public async Task<GetuserDetailsRspDto> GetUserDetailsAsync2(long UserId)
    {
        var key = CommonCacheKey.cacheKey_users_usersdetails;

        var records = await db.StringGetAsync(key);

        var userDetailDto = new List<GetuserDetailsRspDto>();

        using (JsonTextReader reader = new JsonTextReader(new StringReader(records.ToString())))
        {
            JsonSerializer serializer = new JsonSerializer();
            userDetailDto = serializer.Deserialize<List<GetuserDetailsRspDto>>(reader);
        }

        var user = userDetailDto.Where(x => x.UserId == UserId).FirstOrDefault();

        return user ?? new GetuserDetailsRspDto();
    }
    #endregion

    #region GetUserIds
    /// <summary>
    /// GetUserIds
    /// </summary>
    /// <returns>Task<List<int>></returns>
    public async Task<List<int>> GetUserIds()
    {
        var configuration = ConfigurationOptions.Parse(redisConnection);
        var server = redis?.GetServer(configuration.EndPoints.First());

        //  var server = redis.GetServer("localhost", 6379); 
        var allKeys = server.Keys(database: db.Database, pattern: "chatroom:*").ToArray();
        Console.WriteLine($"Found {allKeys.Length} keys matching the pattern.");

        var distinctUserIds = new HashSet<int>();

        foreach (var key in allKeys)
        {
            var records = await db.ListRangeAsync(key);

            foreach (var r in records)
            {
                using (JsonTextReader reader = new JsonTextReader(new StringReader(r.ToString())))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    var messageDetailDto = serializer.Deserialize<MessageDetailDto>(reader);

                    // Assuming MessageDetailDto has a property named UserId
                    distinctUserIds.Add((int)messageDetailDto.UserId);
                }
            }
        }

        return [.. distinctUserIds];
    }
    #endregion

    #region MapUserDetails

    #region MapUsersDetailsList
    /// <summary>
    /// MapUsersDetailsList
    /// </summary>
    /// <param name="messagesList"></param>
    /// <returns>Task<List<MessageDetailDto>></returns>
    public async Task<List<MessageDetailDto>> MapUsersDetailsList(List<MessageDetailDto> messagesList)
    {
        List<GetuserDetailsRspDto> userDetailsList = await GetAllUsersDetails();

        Dictionary<long, (string UserName, string NickName, string UserPhoto)> userIdToNameMap =
            new Dictionary<long, (string UserName, string NickName, string UserPhoto)>();

        #region Populate user details dictionary, handling duplicate keys
        foreach (var user in userDetailsList)
        {
            if (!userIdToNameMap.ContainsKey((long)user.UserId))
            {
                userIdToNameMap.Add(
                 (long)user.UserId,
                 (user.UserName ?? "", user.NickName ?? "", user.UserPhoto ?? ""));
            }
            else
            {
                Console.WriteLine($"Duplicate key found for user ID: {user.UserId}");
            }
        }
        #endregion

        #region Update user names and nicknames in MessageDetailDto based on user ID
        foreach (var message in messagesList)
        {
            if (message.UserId.HasValue && userIdToNameMap.ContainsKey(message.UserId.Value))
            {
                var (userName, nickName, userphoto) = userIdToNameMap[message.UserId.Value];
                message.UserName = userName;
                message.NickName = nickName;
                message.UserPhoto = userphoto;
            }
        }
        #endregion

        return messagesList;
    }
    #endregion

    #region MapUserDetailsAsync
    /// <summary>
    /// MapUserDetailsAsync
    /// </summary>
    /// <param name="messageDetail"></param>
    /// <returns>Task<MessageDetailDto></returns>
    public async Task<MessageDetailDto> MapUserDetailsAsync(MessageDetailDto messageDetail)
    {
        List<GetuserDetailsRspDto> userDetailsList = await GetAllUsersDetails();

        Dictionary<long, (string UserName, string NickName, string UserPhoto)> userIdToNameMap =
            new Dictionary<long, (string UserName, string NickName, string UserPhoto)>();

        #region Populate user details dictionary, handling duplicate keys
        foreach (var user in userDetailsList)
        {
            if (!userIdToNameMap.ContainsKey((long)user.UserId))
            {
                userIdToNameMap.Add(
                 (long)user.UserId,
                 (user.UserName ?? "", user.NickName ?? "", user.UserPhoto ?? ""));
            }
            else
            {
                Console.WriteLine($"Duplicate key found for user ID: {user.UserId}");
            }
        }
        #endregion

        #region Update user names and nicknames in MessageDetailDto based on user ID
        if (messageDetail.UserId.HasValue && userIdToNameMap.ContainsKey(messageDetail.UserId.Value))
        {
            var (userName, nickName, userphoto) = userIdToNameMap[messageDetail.UserId.Value];
            messageDetail.UserName = userName;
            messageDetail.NickName = nickName;
            messageDetail.UserPhoto = userphoto;
        }
        #endregion

        return messageDetail;
    }
    #endregion

    #endregion

    #endregion

    #region General Management

    #region PushJsonObjectToRedisAsync
    /// <summary>
    /// PushJsonObjectToRedisAsync
    /// </summary>
    /// <param name="message"></param>
    /// <param name="key"></param>
    /// <returns>Task<MessageDetailDto></returns>
    public void PushJsonObjectToRedisAsync(string message, string key)
    {
        // string jsonMessage = JsonConvert.SerializeObject(message);

        PushJsonObject(db, key, message);
    }
    #endregion

    #region PushJsonObject
    /// <summary>
    /// PushJsonObject
    /// </summary>
    /// <param name="db"></param>
    /// <param name="chatRoomKey"></param>
    /// <param name="message"></param>
    /// <returns>Task<List<int>></returns>
    private static void PushJsonObject(IDatabase db, string chatRoomKey, string message)
    {
        string formattedMessage = $"{message}";
        Console.WriteLine("-->RedisServer: calling PushJsonObject");
        db.ListRightPush(chatRoomKey, formattedMessage);
        Console.WriteLine($"-->RedisServer: message pushed to redis");
    }
    #endregion

    #region PushSingleObject
    /// <summary>
    /// PushSingleObject
    /// </summary>
    /// <param name="key"></param>
    /// <param name="objects"></param>
    /// <returns>bool</returns>
    public bool PushSingleObject(string key, List<LotteryUserDetailsRspDto> objects)
    {
        return db.StringSet(key, JsonConvert.SerializeObject(objects));
    }
    #endregion

    #region PushObjectList
    /// <summary>
    /// PushObjectList
    /// </summary>
    /// <param name="key"></param>
    /// <param name="objects"></param>
    /// <returns>bool</returns>
    public bool PushObjectList(string key, List<LotteryUserDetailsRspDto> objects)
    {
        // Serialize each object to JSON and push to the Redis list
        foreach (var obj in objects)
        {
            string serializedObject = JsonConvert.SerializeObject(obj);
            db.ListRightPush(key, serializedObject);
            Console.WriteLine($"Pushed object to Redis: {serializedObject}");
        }
        return true;
    }
    #endregion

    #region PushObjectList
    /// <summary>
    /// PushObjectList
    /// </summary>
    /// <param name="key"></param>
    /// <param name="objects"></param>
    /// <returns>bool</returns>
    public async Task<bool> PushMessagesList(List<MessageDetailDto> objects, string roomId)
    {
        string key = string.Format(CommonCacheKey.chatroom, roomId);
        // Serialize each object to JSON and push to the Redis list
        foreach (var obj in objects)
        {
            string serializedObject = JsonConvert.SerializeObject(obj);
            await db.ListRightPushAsync(key, serializedObject);
            Console.WriteLine($"Pushed object to Redis: {serializedObject}");
        }
        return true;
    }
    #endregion

    #region PushSingleObjectToCache
    /// <summary>
    /// PushObjectList
    /// </summary>
    /// <param name="key"></param>
    /// <param name="objects"></param>
    /// <returns>bool</returns>
    public bool PushSingleObjectToCache(string key, object obj)
    {
        try
        {

            string serializedObject = JsonConvert.SerializeObject(obj);
            db.ListRightPush(key, serializedObject);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
        
    }
    #endregion

    #region PushListObjectToCache
    /// <summary>
    /// PushObjectList
    /// </summary>
    /// <param name="key"></param>
    /// <param name="objList"></param>
    /// <returns>bool</returns>
    public bool PushListObjectToCache(string key, List<object> objList)
    {
        try
        {
            foreach (var obj in objList)
            {
                string serializedObject = JsonConvert.SerializeObject(obj);
                db.ListRightPush(key, serializedObject);
            }
                
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }
    #endregion

    #region RemoveKey
    public bool RemoveKey(string key)
    {
        return db.KeyDelete(key);
    }
    #endregion

    #endregion


    #region Dispose
    public void Dispose()
    {
        redis?.Dispose();
    }
    #endregion
}