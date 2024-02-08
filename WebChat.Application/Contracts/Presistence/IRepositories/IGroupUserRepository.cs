namespace WebChat.Application.Contracts.Presistence.IRepositories;

#region IGroupUserRepository
#region IGroupUserRepository Contract Summary
/// <summary>
/// IGroupUserRepository Contract
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public interface IGroupUserRepository : IBaseRepository<GroupUsersEntity>
{
    Task<ApiResponse<PageBaseResponse<List<GroupUserDetailDto>>>> GetGroupUserDetailsAsync(GetGroupUserReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<GroupUserDetailDto>> GetSingleGroupUserDetailsAsync(long Id, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> AddGroupUserAsync(AddGroupUserReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> AddBulkGroupUserAsync(List<AddBulkGroupUserReqDto> reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> DeleteGroupUserAsync(DeleteGroupUserReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> UpdateGroupUserAsync(UpdateGroupUserReqDto reqest, CancellationToken cancellationToken = default);
}

#endregion