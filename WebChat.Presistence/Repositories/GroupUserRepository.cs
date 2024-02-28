using WebChat.Common.Dto.RequestDtos.GroupUser;
using WebChat.Common.Dto.ResponseDtos.GroupUser;

namespace WebChat.Presistence.Repositories;

public class GroupUserRepository(
    WebchatDBContext context, 
    IConfiguration configuration, 
    IHttpContextAccessor httpContextAccessor, 
    IAppSettings appSettings) 
    : BaseRepository<GroupUsersEntity>(
        context, 
        configuration, 
        httpContextAccessor, 
        appSettings), IGroupUserRepository
{
    #region AddBulkGroupUserAsync
    #region Summary
    /// <summary>
    /// AddBulkGroupUserAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Operation completed successfully.</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddBulkGroupUserAsync(List<AddBulkGroupUserReqDto> reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Mapping Domain Entity with response
        var entity = reqest.Select(x => new GroupUsersEntity
        {

            UserId = x.UserId,
            GroupId = x.GroupId,
            SubGroupId = x.SubGroupId,
            CreatedBy = x.UserId,

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

    #region AddGroupUserAsync
    #region Summary
    /// <summary>
    /// AddGroupUserAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Operation completed successfully.</returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddGroupUserAsync(AddGroupUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Mapping with Domain Entity
        var entity = new GroupUsersEntity
        {
            UserId = reqest.UserId,
            GroupId = reqest.GroupId,
            SubGroupId = reqest.SubGroupId,
            CreatedBy = reqest.UserId
        };
        #endregion

        Expression<Func<GroupUsersEntity, bool>> predicate = user => user.UserId == reqest.UserId;

        var exist = await GetAvailablePredicateAsync(predicate);
        if(exist == null)
        {
            #region Add Entity into Database...
            var res = await AddAsync(entity, cancellationToken);
            #endregion

            #region Response
            if (res.Code != null && ((int)res.Code != (int)DbCodeEnums.Failed && (int)res.Code != (int)DbCodeEnums.DbException))
            {
                return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }
       
        return new ApiResponse<bool> { Data = false };
        #endregion 
        #endregion
    }
    #endregion

    #region DeleteGroupUserAsync
    #region Summary
    /// <summary>
    /// DeleteGroupUserAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Operation completed successfully.</returns> 
    #endregion
    public async Task<ApiResponse<bool>> DeleteGroupUserAsync(DeleteGroupUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Check Message Id Exist or not...
        var entity = await GetAvailableAsync(reqest.Id?? -1, cancellationToken);

        #endregion

        #region Delete Permanentaly from database
        if (entity != null)
        {
            var response = await DeletePermanentlyAsync(entity,cancellationToken);
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

    #region GetGroupUserDetailsAsync
    #region Summary
    /// <summary>
    /// GetGroupUserDetailsAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Operation completed successfully.</returns> 
    #endregion
    public async Task<ApiResponse<PageBaseResponse<List<GroupUserDetailDto>>>> GetGroupUserDetailsAsync(GetGroupUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...

        #region Predicate Filter
        Expression<Func<GroupUsersEntity, bool>>? predicate = message => message.IsActive;

        if (reqest.UserId != null)
        {
            predicate = predicate.AndAlso(message=> message.UserId == reqest.UserId);
        }

        if (reqest.GroupId != null)
        {
            predicate = predicate.AndAlso(message => message.GroupId == reqest.GroupId);
        }

        if (reqest.SubGroupId != null)
        {
            predicate = predicate.AndAlso(message => message.GroupId == reqest.SubGroupId);
        }
        #endregion

        #region Get All Data From Database
        var response = await GetPagedAsync(reqest.PageNo, reqest.PageSize, predicate, cancellationToken);
        #endregion

        #region Response
        if (response != null)
        {
            var lst = response?.List?.Select(x => new GroupUserDetailDto
            {
                GroupUserId = x.Id,
                UserId = x.UserId,
                GroupId = x?.GroupId,
                GroupName = x?.Group?.Name,
                SubGroupId = x?.SubGroupId,
                SubGroupName = x?.SubGroup?.Name,

            }).ToList();
            var result = new PageBaseResponse<List<GroupUserDetailDto>>()
            { List = lst, PageNo = response?.PageNo, TotalPage = response?.TotalPage, TotalCount = response?.TotalCount };

            return new ApiResponse<PageBaseResponse<List<GroupUserDetailDto>>> { Data = result, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        return new ApiResponse<PageBaseResponse<List<GroupUserDetailDto>>>();
        #endregion 
        #endregion
    }
    #endregion

    #region GetSingleGroupUserDetailsAsync
    #region Summary
    /// <summary>
    /// GetSingleGroupUserDetailsAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns> 
    #endregion
    public async Task<ApiResponse<GroupUserDetailDto>> GetSingleGroupUserDetailsAsync(long Id, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Predicate Filter
        Expression<Func<GroupUsersEntity, bool>> predicate = user => user.IsActive && user.Id == Id;
        #endregion

        #region Get Data Based on Filter from Database
        if (predicate != null)
        {
            var response = GetAll(predicate,cancellationToken);
            if (response != null)
            {
                var lst = response.Select(x => new GroupUserDetailDto
                {
                    GroupUserId = x.Id,
                    UserId = x.UserId,
                    GroupId = x.GroupId,
                    GroupName = x.Group.Name,
                    SubGroupId = x.SubGroupId,
                    SubGroupName = x.SubGroup.Name,
                }).FirstOrDefault();
                if (lst != null)
                {
                    return new ApiResponse<GroupUserDetailDto> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
                }
                else
                {
                    return new ApiResponse<GroupUserDetailDto> { Data = lst, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.NotFound };
                }


            }
        }
        #endregion

        #region Default Response
        return new ApiResponse<GroupUserDetailDto>();
        #endregion 
        #endregion
    }
    #endregion

    #region UpdateGroupUserAsync
    #region Summary
    /// <summary>
    /// UpdateGroupUserAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns> 
    #endregion
    public async Task<ApiResponse<bool>> UpdateGroupUserAsync(UpdateGroupUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Entity Mapping
        var entity = new GroupUsersEntity
        {
            Id = reqest.GroupUserId,
            UserId = reqest.UserId,
            GroupId = reqest.GroupId,
            SubGroupId = reqest.SubGroupId,
            ModifiedBy = reqest.UserId,
            UtcDateModified = DateTime.UtcNow,
        };
        #endregion

        #region Data Updating with Database
        var response = await UpdateAsync(entity, updatedBy: reqest.UserId, cancellationToken);
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

    #region DeleteGroupUserPredicateAsync
    #region Summary
    /// <summary>
    /// DeleteGroupUserPredicateAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 16-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Operation completed successfully.</returns> 
    #endregion
    public async Task<ApiResponse<bool>> DeleteGroupUserPredicateAsync(DeleteGroupUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region ...
        #region Check Message Id Exist or not...
        Expression<Func<GroupUsersEntity, bool>>? predicate = g => g.UserId == reqest.UserId;

        var entity = await GetAvailablePredicateAsync(predicate, cancellationToken);

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
}
