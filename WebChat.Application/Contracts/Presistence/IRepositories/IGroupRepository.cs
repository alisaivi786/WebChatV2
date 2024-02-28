namespace WebChat.Application.Contracts.Presistence.IRepositories;

/// <summary>
/// IGroupRepository
/// Developer: ALI RAZA MUSHTAQ
/// Date: 06-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
public interface IGroupRepository : IBaseRepository<GroupEntity>
{
    Task<ApiResponse<PageBaseResponse<List<GroupDetailRspDto>>>> GetGroupDetailsAsync(GetGroupReqDto reqest);
    Task<ApiResponse<GroupDetailRspDto>> GetSingleGroupDetailsAsync(long Id);
    Task<ApiResponse<bool>> AddGroupAsync(AddGroupReqDto reqest);
    Task<ApiResponse<bool>> AddBulkGroupAsync(List<AddGroupReqDto> reqest);
    Task<ApiResponse<bool>> DeleteGroupAsync(DeleteGroupReqDto reqest);
    Task<ApiResponse<bool>> UpdateGroupAsync(UpdateGroupReqDto reqest);
}
