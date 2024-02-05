using WebChat.Application.ApplicationSettings;
using WebChat.Application.Contracts.Presistence.IRepositories;
using WebChat.Common.Dto.ResponseDtos.Users;
using WebChat.Presistence.Repositories.BaseRepository;

namespace WebChat.Presistence.Repositories;

public class UserRepository(
    WebchatDBContext context,
    IConfiguration configuration,
    IHttpContextAccessor httpContextAccessor,
    AppSettings appSettings) : BaseRepository<UserEntity>(
        context,
        configuration,
        httpContextAccessor,
        appSettings), IUserRepository
{


    // Add Custom Function here....

    public async Task<ApiResponse<bool>> AddBulkUserAsync(List<AddUserDto> reqest)
    {
        #region Binding Request with Domain Entity Model
        //============================================================
        var entity = reqest.Select(x => new UserEntity {
            UserName = x.Name,
            PhoneNumber = x.PhoneNumber
        }).ToList();
        //============================================================ 
        #endregion

        #region Calling DB Base Repository
        var response = await AddMultipleAsync(entity);
        #endregion

        if (response.Code != null && (int)response.Code != (int)ApiCodeEnum.Failed)
        {
            // Mapp Response with Api Response
            return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        else
        {
            return new ApiResponse<bool> { Data = false, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.Failed };
        }
    }

    public async Task<ApiResponse<bool>> AddUserAsync(AddUserDto reqest)
    {

        #region Binding Request with Domain Entity Model
        //============================================================
        var entity = new UserEntity()
        {
            UserName = reqest.Name,
            PhoneNumber = reqest.PhoneNumber
        };
        //============================================================ 
        #endregion

        #region Calling DB Base Repository
        var response = await AddAsync(entity);
        #endregion

        if (response.Code != null && (int)response.Code != (int)ApiCodeEnum.Failed)
        {
            // Mapp Response with Api Response
            return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }
        else
        {
            return new ApiResponse<bool> { Data = false, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.Failed };
        }

    }

    public Task<ApiResponse<bool>> DeleteUserAsync(DeleteUserDto reqest)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<UserDetailDto>> GetSingleUserDetailsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<UserDetailDto>> GetUserDetailsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<bool>> UpdateUserAsync(UpdateUserDto reqest)
    {
        throw new NotImplementedException();
    }
}
