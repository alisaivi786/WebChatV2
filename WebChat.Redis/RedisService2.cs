
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using WebChat.Application.ApplicationSettings;


namespace WebChat.Redis;

/// <summary>
/// IRedisService Class
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 27-02-2024
/// </summary>
public class RedisService2<T> : IRedisService2<T>
{
    #region private fields initialization
    private readonly IConnectionMultiplexer redis;
    private readonly IDatabase db;
    private readonly int chatRoomLimit = 1000;
    #endregion

    #region Constructor Initialization
    public RedisService2(IConnectionMultiplexer redis, IAppSettings appSetting)
    {
        this.redis = redis;
        db = redis.GetDatabase();
        chatRoomLimit = Convert.ToInt32(appSetting.RedisCharRoomLimit);
    }
    #endregion

    #region PushMessageToRedisAsync
    /// <summary>
    /// PushMessageToRedisAsync
    /// </summary>
    /// <param name="message"></param>
    /// <param name="key"></param>
    /// <returns>void</returns>
    public void PushMessageToRedisAsync(string key, T message)
    {
        PushJsonObject(key, message);
        RetrieveDisplayAndTrimMessages(key, chatRoomLimit);
    }
    #endregion

    #region PushJsonObject
    /// <summary>
    /// PushJsonObject
    /// </summary>
    /// <param name="key"></param>
    /// <param name="obj"></param>
    /// <returns>void</returns>
    private void PushJsonObject(string key, T obj)
    {
        string serializedObj = JsonConvert.SerializeObject(obj);
        db.ListRightPush(key, serializedObj);
    }
    #endregion

    #region RetrieveDisplayAndTrimMessages
    /// <summary>
    /// RetrieveDisplayAndTrimMessages
    /// </summary>
    /// <param name="db"></param>
    /// <param name="chatRoomKey"></param>
    /// <param name="messageCountToKeep"></param>
    /// <returns>void</returns>
    private void RetrieveDisplayAndTrimMessages(string chatRoomKey, int messageCountToKeep)
    {
        RedisValue[] messages = db.ListRange(chatRoomKey);
        db.ListTrim(chatRoomKey, -messageCountToKeep, -1);
    }
    #endregion

    #region GetRedisListAsync
    /// <summary>
    /// GetRedisListAsync
    /// </summary>
    /// <param name="key"></param>
    /// <returns>List<T></returns>
    public async Task<List<T>> GetRedisListAsync(string key)
    {
        var records = await db.ListRangeAsync(key);
        var redisList = new List<T>();

        foreach (var r in records)
        {
            T messageDetailDto = JsonConvert.DeserializeObject<T>(r);
            redisList.Add(messageDetailDto);
        }

        return redisList;
    }
    #endregion

    #region GetRedisCountAsync
    /// <summary>
    /// GetRedisCountAsync
    /// </summary>
    /// <param name="key"></param>
    /// <returns>long</returns>
    public async Task<long> GetRedisCountAsync(string key)
    {
        var messagesCount = await db.ListLengthAsync(key);
        return messagesCount;
    }
    #endregion

    #region GetFirstRecordAsync
    /// <summary>
    /// GetFirstRecordAsync
    /// </summary>
    /// <param name="key"></param>
    /// <returns>bool</returns>
    public async Task<T> GetFirstRecordAsync(string key)
    {
        RedisValue firstRecord = db.ListGetByIndex(key, 0);
        T record = default;

        if (!firstRecord.IsNull)
        {
            record = JsonConvert.DeserializeObject<T>(firstRecord);
        }

        return record;
    }
    #endregion

    #region PushSingleObjectAsync
    /// <summary>
    /// PushSingleObjectAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="objects"></param>
    /// <returns>bool</returns>
    public async Task<bool> PushSingleObjectAsync(string key, List<T> objects)
    {
        return await db.StringSetAsync(key, JsonConvert.SerializeObject(objects));
    }
    #endregion

    #region PushObjectListAsync
    /// <summary>
    /// PushObjectListAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="objects"></param>
    /// <returns>bool</returns>
    public async Task<bool> PushObjectListAsync(string key, List<T> objects)
    {
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

    //#region PushObjectList
    ///// <summary>
    ///// PushObjectList
    ///// </summary>
    ///// <param name="key"></param>
    ///// <param name="objects"></param>
    ///// <returns>bool</returns>
    //public async Task<bool> PushMessagesListAsync(string key, List<T> objects)
    //{
    //    // string key = string.Format(CommonCacheKey.chatroom, roomId);
    //    // Serialize each object to JSON and push to the Redis list
    //    foreach (var obj in objects)
    //    {
    //        string serializedObject = JsonConvert.SerializeObject(obj);
    //        await db.ListRightPushAsync(key, serializedObject);
    //        Console.WriteLine($"Pushed object to Redis: {serializedObject}");
    //    }
    //    return true;
    //}
    //#endregion

    #region PushSingleObjectToCacheAsync
    /// <summary>
    /// PushSingleObjectToCacheAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="obj"></param>
    /// <returns>bool</returns>
    public async Task<bool> PushSingleObjectToCacheAsync(string key, object obj)
    {
        try
        {
            string serializedObject = JsonConvert.SerializeObject(obj);
            await db.ListRightPushAsync(key, serializedObject);
            return true;
        }
        catch (Exception)
        {

            return false;
        }

    }
    #endregion

    #region PushOrReplaceObject
    /// <summary>
    /// PushOrReplaceObject
    /// </summary>
    /// <param name="listKey"></param>
    /// <param name="Data"></param>
    /// <param name="field"></param>
    /// <returns>Task</returns>
    public async Task<bool> PushOrReplaceObject(string listKey, T Data, string field)
    {
        var jsonString = JsonConvert.SerializeObject(Data);

        int Id = GetIdFromJson(jsonString, field);

        if (ObjectExists(listKey, Id, field))
        {
            var index = GetIndexById(listKey, Id, field);
            await db.ListSetByIndexAsync(listKey, index, jsonString);
        }
        else
        {
            await db.ListRightPushAsync(listKey, jsonString);
        }
        return true;
    }
    #endregion

    #region PushOrReplaceObjectList
    /// <summary>
    /// PushOrReplaceObjectList
    /// </summary>
    /// <param name="listKey"></param>
    /// <param name="Data"></param>
    /// <param name="field"></param>
    /// <returns>bool</returns>
    public async Task<bool> PushOrReplaceObjectList(string listKey, List<T> Data, string field)
    {
        foreach (var item in Data)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            int Id = GetIdFromJson(jsonString, field);

            if (ObjectExists(listKey, Id, field))
            {
                var index = GetIndexById(listKey, Id, field);
                await db.ListSetByIndexAsync(listKey, index, jsonString);
            }
            else
            {
                await db.ListRightPushAsync(listKey, jsonString);
            }
        }
        return true;
    }
    #endregion

    #region GetIdFromJson
    /// <summary>
    /// GetIdFromJson
    /// </summary>
    /// <param name="jsonData"></param>
    /// <param name="field"></param>
    /// <returns>int</returns>
    static int GetIdFromJson(string jsonData, string field)
    {

        JObject jsonObject = JObject.Parse(jsonData);

        int userId = jsonObject[field].Value<int>();

        return userId;
    }
    #endregion

    #region ObjectExists
    /// <summary>
    /// ObjectExists
    /// </summary>
    /// <param name="listKey"></param>
    /// <param name="Id"></param>
    /// <param name="field"></param>
    /// <returns>int</returns>
    public bool ObjectExists(string listKey, int Id, string field)
    {
        RedisValue[] listValues = db.ListRange(listKey);

        foreach (RedisValue value in listValues)
        {
            var record = value.ToString();

            var id = GetIdFromJson(record, field);

            if (id == Id)
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    #region GetIndexById
    /// <summary>
    /// GetIndexById
    /// </summary>
    /// <param name="listKey"></param>
    /// <param name="targetId"></param>
    /// <param name="field"></param>
    /// <returns>int</returns>
    public int GetIndexById(string listKey, int targetId, string field)
    {
        RedisValue[] listValues = db.ListRange(listKey);

        for (int i = 0; i < listValues.Length; i++)
        {
            var record = listValues[i].ToString();

            var id = GetIdFromJson(record, field);

            if (id == targetId)
            {
                return i;
            }
        }

        return -1;
    }
    #endregion

    #region IsRedisWorking
    /// <summary>
    /// IsRedisWorking
    /// </summary>
    /// <returns>bool</returns>
    public bool IsRedisWorking()
    {
        try
        {
            db.StringSet("ping", "pong");

            var pingResult = db.StringGet("ping");
            return pingResult.HasValue && pingResult.ToString() == "pong";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking Redis connection: {ex.Message}");
            return false;
        }
    }
    #endregion

    #region Dispose
    /// <summary>
    /// Dispose
    /// </summary>
    /// <returns>void</returns>
    public void Dispose()
    {
        redis?.Dispose();
    }
    #endregion
}
