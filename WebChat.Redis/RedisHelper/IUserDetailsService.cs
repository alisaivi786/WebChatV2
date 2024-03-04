

using WebChat.Common.Dto.ResponseDtos.Message;

namespace WebChat.Redis.RedisHelper;

public interface IUserDetailsService
{
    public Task<List<MessageDetailDto>> MapUsersDetailsListAsync(string key, List<MessageDetailDto> messagesList);
    public Task<MessageDetailDto> MapUserDetailsAsync(string key, MessageDetailDto messageDetail);
}