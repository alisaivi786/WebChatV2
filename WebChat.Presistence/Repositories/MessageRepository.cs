using System.Collections.Generic;
using WebChat.Redis;

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
public class MessageRepository
    (WebchatDBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IAppSettings appSettings)
    : BaseRepository<MessageEntity>(context, configuration, httpContextAccessor, appSettings), IMessageRepository
{
    private readonly WebchatDBContext Ado = context;
    // Property for injecting IRedisService
    //public IRedisService RedisService { get; set; }

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
    public async Task<ApiResponse<bool>> AddBulkMessageAsync(List<AddBulkMessageReqDto> reqest)
    {
        #region ...
        #region Mapping Domain Entity with response
        var entity = reqest.Select(x => new MessageEntity
        {

            UserId = x.UserId,
            SubGroupId = x.SubGroupId,
            Content = x.Content,
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
    public async Task<ApiResponse<bool>> AddMessageAsync(AddMessageReqDto reqest)
    {
        #region ...
        #region Mapping with Domain Entity
        var entity = new MessageEntity
        {
            UserId = reqest.UserId,
            SubGroupId = reqest.SubGroupId,
            Content = reqest.Message,
            SentTime = DateTime.UtcNow,
            UUID = reqest.UUID,
        };
        #endregion

        #region Add Entity into Database...
        var res = await AddAsync(entity);
        #endregion

        #region Response
        if (res.Code != null && ((int)res.Code != (int)DbCodeEnums.Failed && (int)res.Code != (int)DbCodeEnums.DbException))
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
    public async Task<ApiResponse<bool>> DeleteMessageAsync(DeleteMessageReqDto reqest)
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
    public async Task<ApiResponse<PageBaseResponse<List<MessageDetailDto>>>> GetMessageDetailsAsync(GetMessageReqDto reqest, long lastMessageId = int.MaxValue)
    {
        #region ...

        //return await QueryRawSqlAsync(reqest);

        #region Predicate Filter
        // Expression<Func<MessageEntity, bool>>? predicate = message => message.IsActive && message.SubGroupId == reqest.SubGroupId;
        Expression<Func<MessageEntity, bool>>? predicate = message => message.IsActive
        && message.SubGroupId == reqest.SubGroupId
        && message.Id < lastMessageId;
        #endregion

        #region Get All Data From Database
        var response = await GetPagedAsync(reqest.PageNo, reqest.PageSize, predicate);
        #endregion


        #region Response
        if (response != null)
        {
            var lst = response?.List?.Select(x => new MessageDetailDto
            {
                MessageId = x.Id,
                UserId = x.UserId,
                SubGroupId = x?.SubGroupId,
                SubGroupName = x?.SubGroup?.Name,
                GroupId = x?.SubGroup.GroupId,
                GroupName = x?.SubGroup.Group.Name,
                Message = x?.Content,
                Time = x?.UtcDateCreated,
                UUID = x?.UUID,
            }).ToList();

            #region Map User Name from Redis User Details to Message Details
            // var mappedList = await RedisService.MapUsersDetailsList(lst);
            #endregion

            var result = new PageBaseResponse<List<MessageDetailDto>>()
            { List = lst, PageNo = response?.PageNo, TotalPage = response?.TotalPage, TotalCount = response?.TotalCount };
            //   { List = mappedList, PageNo = response?.PageNo, TotalPage = response?.TotalPage, TotalCount = response?.TotalCount };

            return new ApiResponse<PageBaseResponse<List<MessageDetailDto>>> { Data = result, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<PageBaseResponse<List<MessageDetailDto>>>();
        #endregion 
        #endregion
    }
    #endregion

    #region Get Message Details Async
    #region Get Message Details Async Summary
    /// <summary>
    /// Get Message Details
    /// Developer: AYMAN MUSTAFA ADLAN
    /// Date: 27-Feb-2024
    /// </summary>
    /// <returns>Return List of Messages</returns> 
    #endregion
    public async Task<PageBaseResponse<List<MessageDetailDto>>> GetMessageDetailsListAsync(GetMessageReqDto reqest, long lastMessageId = int.MaxValue)
    {
        #region ...

        //return await QueryRawSqlAsync(reqest);

        #region Predicate Filter
        // Expression<Func<MessageEntity, bool>>? predicate = message => message.IsActive && message.SubGroupId == reqest.SubGroupId;
        Expression<Func<MessageEntity, bool>>? predicate = message => message.IsActive
        && message.SubGroupId == reqest.SubGroupId
        && message.Id < lastMessageId;
        #endregion

        #region Get All Data From Database
        var response = await GetPagedAsync(reqest.PageNo, reqest.PageSize, predicate);
        #endregion


        #region Response
        if (response != null)
        {
            var lst = response?.List?.Select(x => new MessageDetailDto
            {
                MessageId = x.Id,
                UserId = x.UserId,
                SubGroupId = x?.SubGroupId,
                SubGroupName = x?.SubGroup?.Name,
                GroupId = x?.SubGroup.GroupId,
                GroupName = x?.SubGroup.Group.Name,
                Message = x?.Content,
                Time = x?.UtcDateCreated,
                UUID = x?.UUID,
            }).ToList();

            //#region Map User Name from Redis User Details to Message Details
            //var mappedList = await RedisService.MapUsersDetailsList(lst);
            //#endregion

            var result = new PageBaseResponse<List<MessageDetailDto>>()
            { List = lst, PageNo = response?.PageNo, TotalPage = response?.TotalPage, TotalCount = response?.TotalCount };

            return result;
        }
        return new PageBaseResponse<List<MessageDetailDto>>();
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
                    // UserName = x.User.UserName,
                    SubGroupId = x.SubGroupId,
                    SubGroupName = x.SubGroup.Name,
                    GroupId = x.SubGroup.GroupId,
                    GroupName = x.SubGroup.Group.Name,
                    Message = x.Content,
                    Time = x.UtcDateCreated
                }).FirstOrDefault();
                if (lst != null)
                {
                    return new ApiResponse<MessageDetailDto> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
                }
                else
                {
                    return new ApiResponse<MessageDetailDto> { Data = lst, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.NotFound };
                }


            }
        }
        #endregion

        #region Default Response
        return new ApiResponse<MessageDetailDto>();
        #endregion 
        #endregion
    }

    public async Task<ApiResponse<MessageDetailDto>> GetSingleMessageDetailsByUUIDAsync(string uuid)
    {
        #region ...
        #region Predicate Filter
        Expression<Func<MessageEntity, bool>> predicate = user => user.IsActive && user.UUID == uuid;
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
                    // UserName = x.User.UserName,
                    SubGroupId = x.SubGroupId,
                    SubGroupName = x.SubGroup.Name,
                    GroupId = x.SubGroup.GroupId,
                    GroupName = x.SubGroup.Group.Name,
                    Message = x.Content,
                    Time = x.UtcDateCreated
                }).FirstOrDefault();
                if (lst != null)
                {
                    return new ApiResponse<MessageDetailDto> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
                }
                else
                {
                    return new ApiResponse<MessageDetailDto> { Data = lst, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.NotFound };
                }


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
    public async Task<ApiResponse<bool>> UpdateMessageAsync(UpdateMessageReqDto reqest)
    {
        #region ...
        #region Entity Mapping
        var entity = new MessageEntity
        {
            Id = reqest.MessageId,
            UserId = reqest.UserId,
            SubGroupId = reqest.SubGroupId,
            Content = reqest.Message,
            ModifiedBy = reqest.UserId,
            UtcDateModified = DateTime.UtcNow,
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


    private async Task<ApiResponse<PageBaseResponse<List<MessageDetailDto>>>> QueryRawSqlAsync(GetMessageReqDto reqest)
    {
        #region ...

        var response = await Ado
                            .Message
                            .FromSqlRaw("SELECT * FROM Message AS m")
                            .OrderBy(m => m.Id)
                            .Skip((reqest.PageNo - 1) * reqest.PageSize)
                            .Take(reqest.PageSize)
                            .ToListAsync();


        #region response
        //var response = await Ado
        //    .Database
        //    .SqlQuery<MessageEntity>($"SELECT * FROM Message AS o")
        //    .OrderBy(o => o.Id)
        //    .Skip((reqest.PageNo - 1) * reqest.PageSize)
        //    .Take(reqest.PageSize)
        //    .ToListAsync();
        #endregion

        #region responseCount
        var totalCount = await Ado
          .Database
          .SqlQuery<MessageEntity>($"SELECT o.Id FROM Message AS o")
      .CountAsync();
        #endregion

        #region totalCount
        var totalPages = (int)Math.Ceiling((double)totalCount / reqest.PageSize);
        #endregion

        #region Response
        if (response != null)
        {
            var lst = response?.Select(x => new MessageDetailDto
            {
                MessageId = x.Id,
                UserId = x.UserId,
                //UserName = x?.User?.UserName,
                SubGroupId = x?.SubGroupId,
                SubGroupName = x?.SubGroup?.Name,
                Message = x?.Content,
                Time = x?.UtcDateCreated


            }).ToList();
            var result = new PageBaseResponse<List<MessageDetailDto>>()
            { List = lst, PageNo = reqest.PageNo, TotalPage = totalPages, TotalCount = totalCount };

            return new ApiResponse<PageBaseResponse<List<MessageDetailDto>>> { Data = result, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<PageBaseResponse<List<MessageDetailDto>>>();
        #endregion 

        #endregion
    }
}
