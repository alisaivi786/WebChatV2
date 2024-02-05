using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.Application.Contracts.Presistence.IBaseRepository;
using WebChat.Application.Response;
using WebChat.Common.Dto.RequestDtos.Message;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.Common.Dto.ResponseDtos.Users;

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
    Task<ApiResponse<List<MessageDetailDto>>> GetMessageDetailsAsync();
    Task<ApiResponse<MessageDetailDto>> GetSingleMessageDetailsAsync(long Id);
    Task<ApiResponse<bool>> AddMessageAsync(AddMessageDto reqest);
    Task<ApiResponse<bool>> AddBulkMessageAsync(List<AddMessageDto> reqest);
    Task<ApiResponse<bool>> DeleteMessageAsync(DeleteMessageDto reqest);
    Task<ApiResponse<bool>> UpdateMessageAsync(UpdateMessageDto reqest);
} 
#endregion
