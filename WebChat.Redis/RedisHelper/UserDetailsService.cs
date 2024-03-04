using WebChat.Common.Dto.ResponseDtos.LotteryUsers;
using WebChat.Common.Dto.ResponseDtos.Message;

namespace WebChat.Redis.RedisHelper;

public class UserDetailsService : IUserDetailsService
{
    private readonly IRedisService2<GetuserDetailsRspDto> RedisService2;

    public UserDetailsService(IRedisService2<GetuserDetailsRspDto> redisService2)
    {
        RedisService2 = redisService2;
    }

    #region MapUserDetailsAsync
    /// <summary>
    /// MapUserDetailsAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="messageDetail"></param>
    /// <returns>Task<List<MessageDetailDto>></returns>
    public async Task<MessageDetailDto> MapUserDetailsAsync(string key, MessageDetailDto messageDetail)
    {
        List<GetuserDetailsRspDto> userDetailsList = await RedisService2.GetRedisListAsync(key);

        Dictionary<long, (string UserName, string NickName, string UserPhoto)> userIdToNameMap =
        new Dictionary<long, (string UserName, string NickName, string UserPhoto)>();

        PopulateUserDetailsDictionary(userDetailsList, userIdToNameMap);

        UpdateUserNamesAndNicknames(messageDetail, userIdToNameMap);

        return messageDetail;
    }
    #endregion

    #region MapUsersDetailsListAsync
    /// <summary>
    /// MapUsersDetailsListAsync
    /// </summary>
    /// <param name="key"></param>
    /// <param name="messagesList"></param>
    /// <returns>Task<List<MessageDetailDto>></returns>
    public async Task<List<MessageDetailDto>> MapUsersDetailsListAsync(string key, List<MessageDetailDto> messagesList)
    {
        List<GetuserDetailsRspDto> userDetailsList = await RedisService2.GetRedisListAsync(key);

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

    #region PopulateUserDetailsDictionary
    private void PopulateUserDetailsDictionary(List<GetuserDetailsRspDto> userDetailsList, Dictionary<long, (string UserName, string NickName, string UserPhoto)> userIdToNameMap)
    {
        foreach (var user in userDetailsList)
        {
            if (!userIdToNameMap.ContainsKey(user.UserId))
            {
                userIdToNameMap.Add(
                 user.UserId,
                 (user.UserName ?? "", user.NickName ?? "", user.UserPhoto ?? ""));
            }
            else
            {
                Console.WriteLine($"Duplicate key found for user ID: {user.UserId}");
            }
        }
    }
    #endregion

    #region UpdateUserNamesAndNicknames
    private void UpdateUserNamesAndNicknames(MessageDetailDto messageDetail, Dictionary<long, (string UserName, string NickName, string UserPhoto)> userIdToNameMap)
    {
        if (messageDetail.UserId.HasValue && userIdToNameMap.ContainsKey(messageDetail.UserId.Value))
        {
            var (userName, nickName, userphoto) = userIdToNameMap[messageDetail.UserId.Value];
            messageDetail.UserName = userName;
            messageDetail.NickName = nickName;
            messageDetail.UserPhoto = userphoto;
        }
    }
    #endregion
}
