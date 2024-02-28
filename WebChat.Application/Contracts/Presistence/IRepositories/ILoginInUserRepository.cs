#region NameSpace
namespace WebChat.Application.Contracts.Presistence.IRepositories;
#endregion

#region ILoginInUserRepository
#region Summary
/// <summary>
/// ILoginInUserRepository
/// Developer: ALI RAZA MUSHTAQ
/// Date: 16-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public interface ILoginInUserRepository : IBaseRepository<LoginInUserEntity>
{
    #region ...
    Task<ApiResponse<PageBaseResponse<List<LoginInUserDetailDto>>>> GetLoginInUserDetailsAsync(GetLoginInUserReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<LoginInUserDetailDto>> GetSingleLoginInUserDetailsAsync(long Id, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> AddLoginInUserAsync(AddLoginInUserReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> AddBulkLoginInUserAsync(List<AddBulkLoginInUserReqDto> reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> DeleteLoginInUserAsync(DeleteLoginInUserReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> UpdateLoginInUserAsync(UpdateLoginInUserReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> DeleteLoginInUserPredicateAsync(DeleteLoginInUserReqDto reqest, CancellationToken cancellationToken = default);
    #endregion
}

#endregion