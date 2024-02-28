
using WebChat.Common.Dto.ResponseDtos.LotteryUsers;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.Common.Dto.ResponseDtos.Users;

namespace WebChat.Redis;

/// <summary>
/// IRedisService Interface
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 05-02-2024
/// </summary>
public interface IRedisService
{
    public void PushMessageToRedisAsync(string message, string roomId);
    public Task<List<MessageDetailDto>> GetAllRedisMessages(string roomId);
    public Task<string> GetLastMessageUUID(string roomId);
    public Task<long> GetRedisCount(string roomId);
    public Task<List<GetuserDetailsRspDto>> GetAllUsersDetails();
    public Task<List<GetuserDetailsRspDto>> GetAllUsersDetails2();
    public Task<GetuserDetailsRspDto> GetUserDetailsAsync(long UserId);
    public Task<GetuserDetailsRspDto> GetUserDetailsAsync2(long UserId);
    public Task<List<int>> GetUserIds();
    public Task<List<MessageDetailDto>> MapUsersDetailsList(List<MessageDetailDto> messagesList);
    public Task<MessageDetailDto> MapUserDetailsAsync(MessageDetailDto messagesList);
    public void PushJsonObjectToRedisAsync(string jsonObject, string key);
    public bool RemoveKey(string key);
    public bool PushSingleObject(string key, List<LotteryUserDetailsRspDto> objects);
    public bool PushObjectList(string key, List<LotteryUserDetailsRspDto> objects);
    bool PushSingleObjectToCache(string key, object obj);
    bool PushListObjectToCache(string key, List<object> objList);
    public Task<bool> PushMessagesList(List<MessageDetailDto> objects, string roomId);
    public void Dispose();
}