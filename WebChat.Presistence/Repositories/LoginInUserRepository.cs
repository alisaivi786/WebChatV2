namespace WebChat.Presistence.Repositories;

#region Summary
/// <summary>
/// LoginInUserRepository
/// Developer: ALI RAZA MUSHTAQ
/// Date: 22-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="context"></param>
/// <param name="configuration"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="appSettings"></param> 
#endregion
public class LoginInUserRepository(WebchatDBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IAppSettings appSettings) 
    : BaseRepository<LoginInUserEntity>(context, configuration, httpContextAccessor, appSettings), ILoginInUserRepository
{
    public Task<ApiResponse<bool>> AddBulkLoginInUserAsync(List<AddBulkLoginInUserReqDto> reqest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #region AddLoginInUserAsync
    #region Summary
    /// <summary>
    /// AddLoginInUserAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 23-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="reqest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns> 
    #endregion
    public async Task<ApiResponse<bool>> AddLoginInUserAsync(AddLoginInUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        #region Mapping Entity
        var entity = new LoginInUserEntity()
        {
            UserId = reqest.UserId,
            UtcLastLoginTime = DateTime.UtcNow,
            CreatedBy = 1
        };
        #endregion

        Expression<Func<LoginInUserEntity, bool>> predicate = user => user.UserId == reqest.UserId;

        var exist = await GetAvailablePredicateAsync(predicate, cancellationToken);
        if (exist == null)
        {
            var response = await AddAsync(entity, cancellationToken);
            if (response != null && response.Code != null && (int)response.Code == (int)DbCodeEnums.Success)
            {
                return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }
        else
        {
            // Update LastLoginInTime
            exist.UtcLastLoginTime = DateTime.UtcNow;
            var response = await UpdateAsync(exist, 1, cancellationToken);
            if (response != null && response.Code != null && (int)response.Code == (int)DbCodeEnums.Success)
            {
                return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }
        return new ApiResponse<bool> { Data = false, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.Failed };
    } 
    #endregion

    public Task<ApiResponse<bool>> DeleteLoginInUserAsync(DeleteLoginInUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> DeleteLoginInUserPredicateAsync(DeleteLoginInUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<PageBaseResponse<List<LoginInUserDetailDto>>>> GetLoginInUserDetailsAsync(GetLoginInUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<LoginInUserDetailDto>> GetSingleLoginInUserDetailsAsync(long Id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> UpdateLoginInUserAsync(UpdateLoginInUserReqDto reqest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
