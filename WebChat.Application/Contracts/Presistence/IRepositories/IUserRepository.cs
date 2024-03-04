using WebChat.Common.Dto.RequestDtos.LotteryUsers;
using WebChat.Common.Dto.RequestDtos.User;
using WebChat.Common.Dto.ResponseDtos.LotteryUsers;

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
public interface IUserRepository : IBaseRepository<UserDetailsEntity>
{
    Task<ApiResponse<List<UserDetailDto>>> GetUserDetailsAsync(GetUserReqDto? reqDto);
    Task<ApiResponse<List<GetuserDetailsRspDto>>> GetLotteryUserDetailsAsync(GetUserDetailsReqDto request);
    Task<ApiResponse<UserDetailDto>> GetSingleUserDetailsAsync(Guid RowId, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> AddUserAsync(AddUserDto reqest);
    Task<ApiResponse<bool>> AddBulkUserAsync(List<AddUserDto> reqest);
    Task<ApiResponse<bool>> DeleteUserAsync(DeleteUserDto reqest);
    Task<ApiResponse<bool>> UpdateUserAsync(UpdateUserReqDto reqest);
    Task<object> Login(LoginReqDTO reqest);
}

#endregion