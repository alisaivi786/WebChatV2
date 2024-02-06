namespace WebChat.Application.Contracts.Presistence.IRepositories;

#region IMessageRepository Contract
#region IMessageRepository Contract Summary
/// <summary>
/// IMessageRepository Contract
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
public interface IMessageRepository : IBaseRepository<MessageEntity>
{
    Task<ApiResponse<PageBaseResponse<List<MessageDetailDto>>>> GetMessageDetailsAsync(GetMessageReqDto reqest);
    Task<ApiResponse<MessageDetailDto>> GetSingleMessageDetailsAsync(long Id);
    Task<ApiResponse<bool>> AddMessageAsync(AddMessageReqDto reqest);
    Task<ApiResponse<bool>> AddBulkMessageAsync(List<AddBulkMessageReqDto> reqest);
    Task<ApiResponse<bool>> DeleteMessageAsync(DeleteMessageReqDto reqest);
    Task<ApiResponse<bool>> UpdateMessageAsync(UpdateMessageReqDto reqest);
} 
#endregion
