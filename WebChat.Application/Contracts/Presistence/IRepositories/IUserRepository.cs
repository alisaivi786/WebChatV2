using WebChat.Application.Contracts.Presistence.IBaseRepository;
using WebChat.Application.Response;
using WebChat.Common.Dto.ResponseDtos.Users;

namespace WebChat.Application.Contracts.Presistence.IRepositories;

#region IUserRepository Contract
#region IUserRepository Contract Summary
/// <summary>
/// IUserRepository Contract
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public interface IUserRepository : IBaseRepository<UserEntity>
{
    Task<ApiResponse<UserDetailDto>> GetUserDetailsAsync();
    Task<ApiResponse<UserDetailDto>> GetSingleUserDetailsAsync();
    Task<ApiResponse<bool>> AddUserAsync(AddUserDto reqest);
    Task<ApiResponse<bool>> AddBulkUserAsync(List<AddUserDto> reqest);
    Task<ApiResponse<bool>> DeleteUserAsync(DeleteUserDto reqest);
    Task<ApiResponse<bool>> UpdateUserAsync(UpdateUserDto reqest);
}

#endregion