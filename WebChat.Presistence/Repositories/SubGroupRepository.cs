﻿#region NameSpace
namespace WebChat.Presistence.Repositories; 
#endregion

#region SubGroupRepository
#region Summary
/// <summary>
/// SubGroupRepository
/// Developer: ALI RAZA MUSHTAQ
/// Date: 23-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="context"></param>
/// <param name="configuration"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="appSettings"></param> 
#endregion
public class SubGroupRepository(WebchatDBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IAppSettings appSettings) : BaseRepository<SubGroupEntity>(context, configuration, httpContextAccessor, appSettings), ISubGroupRepository
{
    #region Add Bulk Sub Group Async
    #region Add Bulk Sub Group Async Summary
    /// <summary>
    /// Add Bulk Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 23-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>return True if Added Successfully</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddBulkSubGroupAsync(List<AddSubGroupReqDto> reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Mapping Domain Entity with response
        var entity = reqest.Select(x => new SubGroupEntity
        {
            Name = x.Name,
            GroupId = x.GroupId,
            CreatedBy = 1,

        }).ToList();
        #endregion

        #region Add Domain Entity into Database...
        var res = await AddMultipleAsync(entity, cancellationToken);
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

    #region AddSubGroupAsync
    #region Add Sub Group Async Summary
    /// <summary>
    /// Add Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 23-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>return True if Added Successfully</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddSubGroupAsync(AddSubGroupReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Mapping with Domain Entity
        var entity = new SubGroupEntity
        {
            Name = reqest.Name,
            GroupId = reqest.GroupId
        };
        #endregion

        #region Add Entity into Database...
        var res = await AddAsync(entity, cancellationToken);
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

    #region Delete Sub Group Async
    #region Delete Sub Group Async Summary
    /// <summary>
    /// Delete Sub Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 23-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>True if Sub Group is Deleted</returns> 
    #endregion
    public async Task<ApiResponse<bool>> DeleteSubGroupAsync(DeleteSubGroupReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Check Group Id Exist or not...
        var entity = await GetAvailableAsync(reqest.Id, cancellationToken);
        #endregion

        #region Delete Permanentaly from database
        if (entity != null)
        {
            var response = await DeletePermanentlyAsync(entity, cancellationToken);
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

    #region GetSubGroupDetailsAsync
    #region Get Sub Group Details Async Summary
    /// <summary>
    /// Get Sub Group Details
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 23-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <returns>List of Sub Group</returns> 
    #endregion
    public async Task<ApiResponse<PageBaseResponse<List<SubGroupDetailRspDto>>>> GetSubGroupDetailsAsync(GetSubGroupReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...

        #region Predicate Filter
        Expression<Func<SubGroupEntity, bool>>? predicate = group => group.IsActive;
        #endregion

        #region Get All Data From Database
        var response = await GetPagedAsync(reqest.PageNo, reqest.PageSize, predicate, cancellationToken);
        #endregion


        #region Response
        if (response != null)
        {
            var lst = response?.List?.Select(x => new SubGroupDetailRspDto
            {
                SubGroupId = x.Id,
                SubGroupName = x.Name,
                GroupId = x.GroupId,
                GroupName = x.Group.Name,

            }).ToList();
            var result = new PageBaseResponse<List<SubGroupDetailRspDto>>()
            { List = lst, PageNo = response?.PageNo, TotalPage = response?.TotalPage, TotalCount = response?.TotalCount };

            return new ApiResponse<PageBaseResponse<List<SubGroupDetailRspDto>>> { Data = result, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<PageBaseResponse<List<SubGroupDetailRspDto>>>();
        #endregion 
        #endregion
    } 
    #endregion

    #region GetSingleSubGroupDetailsAsync
    #region Summary
    /// <summary>
    /// GetSingleSubGroupDetailsAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 23-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>single Sub Group Detail by Id</returns> 
    #endregion
    public async Task<ApiResponse<SubGroupDetailRspDto>> GetSingleSubGroupDetailsAsync(long Id, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Predicate Filter
        Expression<Func<SubGroupEntity, bool>> predicate = user => user.IsActive && user.Id == Id;
        #endregion

        #region Get Data Based on Filter from Database
        if (predicate != null)
        {
            var response = GetAll(predicate, cancellationToken);
            if (response != null)
            {
                var lst = response.Select(x => new SubGroupDetailRspDto
                {
                    SubGroupId = x.Id,
                    SubGroupName = x.Name,
                    GroupId = x.GroupId,
                    GroupName = x.Group.Name,
                }).FirstOrDefault();
                if (lst != null)
                {
                    return new ApiResponse<SubGroupDetailRspDto> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
                }
                else
                {
                    return new ApiResponse<SubGroupDetailRspDto> { Data = lst, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.NotFound };
                }

            }
        }
        #endregion

        #region Default Response
        return new ApiResponse<SubGroupDetailRspDto>();
        #endregion 
        #endregion
    }
    #endregion

    #region UpdateSubGroupAsync
    #region Update Sub Group Async Summary
    /// <summary>
    /// Update Sub Group
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 23-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <returns>True if Updated</returns> 
    #endregion
    public async Task<ApiResponse<bool>> UpdateSubGroupAsync(UpdateSubGroupReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Entity Mapping
        var entity = new SubGroupEntity
        {
            Id = reqest.Id,
            Name = reqest.Name,
            GroupId = reqest.GroupId,
            ModifiedBy = 1,
            UtcDateCreated = DateTime.UtcNow
        };
        #endregion

        #region Data Updating with Database
        var response = await UpdateAsync(entity, updatedBy: 1, cancellationToken);
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

#endregion