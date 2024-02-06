namespace WebChat.Presistence.Repositories;

public class GroupRepository(WebchatDBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, AppSettings appSettings) : BaseRepository<GroupEntitiy>(context, configuration, httpContextAccessor, appSettings), IGroupRepository
{
    #region Add Bulk Group Async
    #region Add Bulk Group Async Summary
    /// <summary>
    /// Add Bulk Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 06-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>return True if Added Successfully</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddBulkGroupAsync(List<AddGroupReqDto> reqest)
    {
        #region ...
        #region Mapping Domain Entity with response
        var entity = reqest.Select(x => new GroupEntitiy
        {
            Name = x.Name,
            CreatedBy = 1,

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

    #region Add Group Async
    #region Add Group Async Summary
    /// <summary>
    /// Add Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 06-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>return True if Added Successfully</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddGroupAsync(AddGroupReqDto reqest)
    {
        #region ...
        #region Mapping with Domain Entity
        var entity = new GroupEntitiy
        {
            Name = reqest.Name,
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

    #region Delete Group Async
    #region Delete Group Async Summary
    /// <summary>
    /// Delete Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 06-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>Return True if Message is Deleted</returns> 
    #endregion
    public async Task<ApiResponse<bool>> DeleteGroupAsync(DeleteGroupReqDto reqest)
    {
        #region ...
        #region Check Group Id Exist or not...
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

    #region Get Group Details Async
    #region Get Group Details Async Summary
    /// <summary>
    /// Get Group Details
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 06-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <returns>Return List of Group</returns> 
    #endregion
    public async Task<ApiResponse<PageBaseResponse<List<GroupDetailRspDto>>>> GetGroupDetailsAsync(GetGroupReqDto reqest)
    {
        #region ...

        #region Predicate Filter
        Expression<Func<GroupEntitiy, bool>>? predicate = group => group.IsActive;
        #endregion

        #region Get All Data From Database
        var response = await GetPagedAsync(reqest.PageNo, reqest.PageSize, predicate);
        #endregion


        #region Response
        if (response != null)
        {
            var lst = response?.List?.Select(x => new GroupDetailRspDto
            {
                GroupId = x.Id,
                GroupName = x.Name,

            }).ToList();
            var result = new PageBaseResponse<List<GroupDetailRspDto>>()
            { List = lst, PageNo = response?.PageNo, TotalPage = response?.TotalPage, TotalCount = response?.TotalCount };

            return new ApiResponse<PageBaseResponse<List<GroupDetailRspDto>>> { Data = result, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<PageBaseResponse<List<GroupDetailRspDto>>>();
        #endregion 
        #endregion
    }
    #endregion

    #region Get Single Group Details Async
    #region Get Single Group Details Async Summary
    /// <summary>
    /// Get Single Group Details
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 06-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>Return Single Group</returns> 
    #endregion
    public async Task<ApiResponse<GroupDetailRspDto>> GetSingleGroupDetailsAsync(long Id)
    {
        #region ...
        #region Predicate Filter
        Expression<Func<GroupEntitiy, bool>> predicate = user => user.IsActive && user.Id == Id;
        #endregion

        #region Get Data Based on Filter from Database
        if (predicate != null)
        {
            var response = GetAll(predicate);
            if (response != null)
            {
                var lst = response.Select(x => new GroupDetailRspDto
                {
                    GroupId = x.Id,
                    GroupName= x.Name,
                }).FirstOrDefault();
                if(lst!= null)
                {
                    return new ApiResponse<GroupDetailRspDto> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
                }
                else
                {
                    return new ApiResponse<GroupDetailRspDto> { Data = lst, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.NotFound };
                }
                
            }
        }
        #endregion

        #region Default Response
        return new ApiResponse<GroupDetailRspDto>();
        #endregion 
        #endregion
    }
    #endregion

    #region Update Group Async
    #region Update Group Async Summary
    /// <summary>
    /// Update Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 05-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>Return True if Updated</returns> 
    #endregion
    public async Task<ApiResponse<bool>> UpdateGroupAsync(UpdateGroupReqDto reqest)
    {
        #region ...
        #region Entity Mapping
        var entity = new GroupEntitiy
        {
            Id = reqest.GroupId,
            Name = reqest.Name,
            ModifiedBy = 1,
            DateCreated = DateTime.UtcNow
        };
        #endregion

        #region Data Updating with Database
        var response = await UpdateAsync(entity, updatedBy: 1);
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
