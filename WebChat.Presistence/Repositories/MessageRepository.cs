namespace WebChat.Presistence.Repositories;

/// <summary>
/// MessageRepository for Message Entity Comunication with Database
/// Developer: ALI RAZA MUSHTAQ
/// Date: 05-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="context"></param>
/// <param name="configuration"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="appSettings"></param>
public class MessageRepository(WebchatDBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, AppSettings appSettings) : BaseRepository<MessageEntity>(context, configuration, httpContextAccessor, appSettings), IMessageRepository
{

    #region Add Bulk Message Async
    #region Add Bulk Message Async Summary
    /// <summary>
    /// Add Bulk Message
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 05-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>return True if Added Successfully</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddBulkMessageAsync(List<AddMessageDto> reqest)
    {
        #region ...
        #region Mapping Domain Entity with response
        var entity = reqest.Select(x => new MessageEntity
        {

            UserId = x.UserId,
            GroupId = x.GroupId,
            Content = x.Message,
            SentTime = DateTime.UtcNow,
            CreatedBy = x.UserId,

        }).ToList();
        #endregion

        #region Add Domain Entity into Database...
        var res = await AddMultipleAsync(entity);
        #endregion

        #region Response
        if (res.Code != null && (int)res.Code != (int)DbCodeEnums.Failed)
        {
            return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<bool> { Data = false };
        #endregion 
        #endregion
    } 
    #endregion

    #region Add Message Async
    #region Add Message Async Summary
    /// <summary>
    /// Add Message
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 05-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>return True if Added Successfully</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddMessageAsync(AddMessageDto reqest)
    {
        #region ...
        #region Mapping with Domain Entity
        var entity = new MessageEntity
        {
            Content = "Hey Team",
            SentTime = DateTime.UtcNow,
        };
        #endregion

        #region Add Entity into Database...
        var res = await AddAsync(entity);
        #endregion

        #region Response
        if (res.Code != null && (int)res.Code != (int)DbCodeEnums.Failed)
        {
            return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<bool> { Data = false };
        #endregion 
        #endregion
    } 
    #endregion

    #region Delete Message Async
    #region Delete Message Async Summary
    /// <summary>
    /// Delete Message
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 05-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>Return True if Message is Deleted</returns> 
    #endregion
    public async Task<ApiResponse<bool>> DeleteMessageAsync(DeleteMessageDto reqest)
    {
        #region ...
        #region Check Message Id Exist or not...
        var entity = await GetAvailableAsync(reqest.Id);
        #endregion

        #region Delete Permanentaly from database
        if (entity != null)
        {
            var response = await DeletePermanentlyAsync(entity);
            if (response.Code != null && (int)response.Code != (int)DbCodeEnums.Failed)
            {
                return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }
        #endregion

        #region Default Response
        return new ApiResponse<bool> { Data = false };
        #endregion
        #endregion

    } 
    #endregion

    #region Get Message Details Async
    #region Get Message Details Async Summary
    /// <summary>
    /// Get Message Details
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 05-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <returns>Return List of Messages</returns> 
    #endregion
    public async Task<ApiResponse<List<MessageDetailDto>>> GetMessageDetailsAsync()
    {
        #region ...
        #region Get All Data From Database
        var response = GetAll();
        #endregion

        #region Response
        if (response != null)
        {
            var lst = response.Select(x => new MessageDetailDto
            {
                MessageId = x.Id,
                UserId = x.UserId,
                GroupId = x.GroupId,
                Message = x.Content,
                Time = x.DateCreated
            }).ToList();
            return new ApiResponse<List<MessageDetailDto>> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<List<MessageDetailDto>>();
        #endregion 
        #endregion
    } 
    #endregion

    #region Get Single Message Details Async
    #region Get Single Message Details Async Summary
    /// <summary>
    /// Get Single Message Details
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 05-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>Return Single Message</returns> 
    #endregion
    public async Task<ApiResponse<MessageDetailDto>> GetSingleMessageDetailsAsync(long Id)
    {
        #region ...
        #region Predicate Filter
        Expression<Func<MessageEntity, bool>> predicate = user => user.IsActive && user.Id == Id;
        #endregion

        #region Get Data Based on Filter from Database
        if (predicate != null)
        {
            var response = GetAll(predicate);
            if (response != null)
            {
                var lst = response.Select(x => new MessageDetailDto
                {
                    MessageId = x.Id,
                    UserId = x.UserId,
                    GroupId = x.GroupId,
                    Message = x.Content,
                    Time = x.DateCreated
                }).FirstOrDefault();
                return new ApiResponse<MessageDetailDto> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }
        #endregion

        #region Default Response
        return new ApiResponse<MessageDetailDto>();
        #endregion 
        #endregion
    } 
    #endregion

    #region Update Message Async
    #region Update Message Async Summary
    /// <summary>
    /// Update Message
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 05-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>Return True if Updated</returns> 
    #endregion
    public async Task<ApiResponse<bool>> UpdateMessageAsync(UpdateMessageDto reqest)
    {
        #region ...
        #region Entity Mapping
        var entity = new MessageEntity
        {
            Id = reqest.MessageId,
            UserId = reqest.UserId,
            GroupId = reqest.GroupId,
            Content = reqest.Message,
            ModifiedBy = reqest.UserId,
            DateModified = DateTime.UtcNow,
            SentTime = DateTime.UtcNow
        };
        #endregion

        #region Data Updating with Database
        var response = await UpdateAsync(entity, updatedBy: reqest.UserId);
        #endregion

        #region Resposne
        if (response.Code != null && (int)response.Code != (int)DbCodeEnums.Failed)
        {
            return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<bool> { Data = false };
        #endregion 
        #endregion

    } 
    #endregion
}
