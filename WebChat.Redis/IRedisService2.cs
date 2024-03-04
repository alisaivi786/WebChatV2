
using StackExchange.Redis;

namespace WebChat.Redis;

/// <summary>
/// IRedisService Interface
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 27-02-2024
/// </summary>
public interface IRedisService2<T>
{
    public void PushMessageToRedisAsync(string key, T message);
    public Task<List<T>> GetRedisListAsync(string key);
    public Task<long> GetRedisCountAsync(string key);
    public Task<T> GetFirstRecordAsync(string key);
    public Task<bool> PushSingleObjectAsync(string key, List<T> objects);
    public Task<bool> PushObjectListAsync(string key, List<T> objects);
    //public Task<bool> PushMessagesListAsync(string key, List<T> objects);
    public Task<bool> PushSingleObjectToCacheAsync(string key, object obj);
    public Task<bool> PushOrReplaceObject(string listKey, T userData, string field);

    public Task<bool> PushOrReplaceObjectList(string listKey, List<T> Data, string field);

    public bool IsRedisWorking();

    public void Dispose();
}