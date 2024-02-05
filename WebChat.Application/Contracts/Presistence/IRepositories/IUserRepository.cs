using WebChat.Application.Contracts.Presistence.IBaseRepository;
using WebChat.Application.Response;
using WebChat.Common.Dto.ResponseDtos.Users;

namespace WebChat.Application.Contracts.Presistence.IRepositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<ApiResponse<UserDetailDto>> GetUserDetailsAsync();
    Task<ApiResponse<UserDetailDto>> GetSingleUserDetailsAsync();
    Task<ApiResponse<bool>> AddUserAsync(AddUserDto reqest);
    Task<ApiResponse<bool>> AddBulkUserAsync(List<AddUserDto> reqest);
    Task<ApiResponse<bool>> DeleteUserAsync(DeleteUserDto reqest);
    Task<ApiResponse<bool>> UpdateUserAsync(UpdateUserDto reqest);
}
