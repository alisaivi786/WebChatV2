namespace WebChat.Application.Contracts.Presistence.IRepositories;

public interface ISubGroupRepository : IBaseRepository<SubGroupEntity>
{
    Task<ApiResponse<PageBaseResponse<List<SubGroupDetailRspDto>>>> GetSubGroupDetailsAsync(GetSubGroupReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<SubGroupDetailRspDto>> GetSingleSubGroupDetailsAsync(long Id, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> AddSubGroupAsync(AddSubGroupReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> AddBulkSubGroupAsync(List<AddSubGroupReqDto> reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> DeleteSubGroupAsync(DeleteSubGroupReqDto reqest, CancellationToken cancellationToken = default);
    Task<ApiResponse<bool>> UpdateSubGroupAsync(UpdateSubGroupReqDto reqest, CancellationToken cancellationToken = default);
}
