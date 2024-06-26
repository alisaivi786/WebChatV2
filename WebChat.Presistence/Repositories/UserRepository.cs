﻿

using SharpCompress.Common;
using System.Threading;
using WebChat.Common.Dto.RequestDtos.GroupUser;
using WebChat.Redis;

namespace WebChat.Presistence.Repositories;

#region Summary
/// <summary>
/// User Repository
/// Developer: ALI RAZA MUSHTAQ
/// Date: 06-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="context"></param>
/// <param name="configuration"></param>
/// <param name="httpContextAccessor"></param>
/// <param name="appSettings"></param>
/// <param name="authService"></param> 
#endregion
public class UserRepository(WebchatDBContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IAppSettings appSettings, IAuthService authService,
   // IRedisService redisService,
    IRedisService2<object> redisService2
    )
    : BaseRepository<UserDetailsEntity>(context, configuration, httpContextAccessor, appSettings: appSettings), IUserRepository
{
    private readonly IAppSettings appSettings = appSettings;

    private readonly IRedisService2<object> RedisService2 = redisService2;

    #region LoginInUserRepository
    public ILoginInUserRepository LoginInUserRepository = new LoginInUserRepository(context, configuration, httpContextAccessor, appSettings);
    #endregion

    #region GroupUserRepository
    public IGroupUserRepository GroupUserRepository = new GroupUserRepository(context, configuration, httpContextAccessor, appSettings);
    #endregion

    private readonly IAuthService AuthService = authService;

    public async Task<object> Login(LoginReqDTO reqest)
    {
        if (true
            //&& !string.IsNullOrWhiteSpace(reqest.Password) 
            )
        {

            // Call Lottery DB to Authenticate the Users:
            using AdoNetDatabase<LotteryUserDetailsRspDto> Ado = new(appSettings);
            var lotteryResponse = Ado
                .GetSingleRow<LotteryUserDetailsRspDto>(
                "lottery.dbo.VW_Chat_User_Details",
                ["UserId", "UserName", "Password", "NickName", "UserPhoto"],
                $"UserName='{reqest.UserName}'");

            if (
                lotteryResponse != null && lotteryResponse.UserId != 0
                //&& reqest.Password.Equals(lotteryResponse.Password) Later we Check Password to verifiy the Users
                )
            {
                #region Save/Update User Info then generate a Token

                AddGroupUserReqDto addGroupUser = new()
                {
                    UserId = lotteryResponse.UserId,
                    GroupId = reqest.GroupId,
                    SubGroupId = reqest.GroupId,
                };
                var response = await GroupUserRepository.AddGroupUserAsync(addGroupUser);

                var AddUserDto = new AddUserDto()
                {
                    UserId = lotteryResponse.UserId,
                    UserName = lotteryResponse.UserName,
                    NickName = lotteryResponse.NickName,
                    Photo = lotteryResponse.UserPhoto
                };
                var SaveUserDetails = await AddUserAsync(AddUserDto);
                #endregion

                // Generate Token
                var Token = await AuthService.GenerateJwtToken(lotteryResponse.UserId.ToString());
                return Token;
            }
        }
        return "";
    }

    // Add Custom Function here....

    public async Task<ApiResponse<bool>> AddBulkUserAsync(List<AddUserDto> reqest)
    {
        #region Binding Request with Domain Entity Model
        //============================================================
        var entity = reqest.Select(x => new UserDetailsEntity
        {
            UserName = x.UserName,
            NickName = x.NickName,
            UserId = Convert.ToInt32(x.UserId),
            UserPhoto = x.Photo,
            CreatedBy = 1

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
        var entity = new UserDetailsEntity()
        {
            UserName = reqest.UserName,
            NickName = reqest.NickName,
            UserId = Convert.ToInt32(reqest.UserId),
            UserPhoto = reqest.Photo,
            CreatedBy = reqest.UserId

        };
        //============================================================ 
        #endregion

        Expression<Func<UserDetailsEntity, bool>> predicate = user => user.UserId == reqest.UserId;

        var exist = await GetAvailablePredicateAsync(predicate);
        if (exist == null)
        {
            #region Calling DB Base Repository
            var response = await AddAsync(entity);

            #region Update Entity into Cache:
            if(await RedisService2.IsKeyAvailable(CommonCacheKey.cacheKey_users_usersdetails))
            {
                UserDetailDto userDetailDto = new()
                {
                    Id = entity.Id,
                    UserId = Convert.ToInt32(entity.UserId),
                    UserName = entity.UserName,
                    UserPhoto = entity.UserPhoto,
                    RowId = entity.RowId,
                    NickName = entity.NickName,
                };
                await RedisService2.PushOrReplaceObject(CommonCacheKey.cacheKey_users_usersdetails, userDetailDto, "UserId");
            }
            else
            {
                var userDetailsList = GetAll();
                var userDetailsListCache = userDetailsList.Select(X=> (object)new UserDetailDto {
                    Id = X.Id,
                    UserId = Convert.ToInt32(X.UserId),
                    UserName = X.UserName,
                    UserPhoto = X.UserPhoto,
                    RowId = X.RowId,
                    NickName = X.NickName,
                }).ToList();

                await RedisService2.PushObjectListAsync(CommonCacheKey.cacheKey_users_usersdetails, userDetailsListCache);
            }
            #endregion

            #endregion

            if (response.Code != null && (int)response.Code != (int)ApiCodeEnum.Failed)
            {
                return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }
        else
        {
            exist.UtcLastLoginTime = DateTime.UtcNow;
            var response = await UpdateAsync(exist, reqest.UserId);

            #region Add Or Update UserDetails into Cache
            if (await RedisService2.IsKeyAvailable(CommonCacheKey.cacheKey_users_usersdetails))
            {
                UserDetailDto userDetailDto = new()
                {
                    Id = Convert.ToInt32(response.Data?.Id),
                    UserId = Convert.ToInt32(response.Data?.UserId),
                    UserName = response.Data?.UserName,
                    UserPhoto = response.Data?.UserPhoto,
                    RowId = response.Data?.RowId,
                    NickName = response.Data?.NickName,
                };
                await RedisService2.PushOrReplaceObject(CommonCacheKey.cacheKey_users_usersdetails, userDetailDto, "UserId");
            }
            else
            {
                var userDetailsList = GetAll();
                var userDetailsListCache = userDetailsList.Select(X => (object)new UserDetailDto
                {
                    Id = X.Id,
                    UserId = Convert.ToInt32(X.UserId),
                    UserName = X.UserName,
                    UserPhoto = X.UserPhoto,
                    RowId = X.RowId,
                    NickName = X.NickName,
                }).ToList();

                await RedisService2.PushObjectListAsync(CommonCacheKey.cacheKey_users_usersdetails, userDetailsListCache);
            } 
            #endregion

            if (response != null && response.Code != null && (int)response.Code == (int)DbCodeEnums.Success)
            {
                return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }

        return new ApiResponse<bool> { Data = false, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.Failed };


    }

    public Task<ApiResponse<bool>> DeleteUserAsync(DeleteUserDto reqest)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<List<GetuserDetailsRspDto>>> GetLotteryUserDetailsAsync(GetUserDetailsReqDto request)
    {
        using AdoNetDatabase<GetuserDetailsRspDto> database = new(appSettings);

        List<GetuserDetailsRspDto> result = database
            .SelectData("lottery.dbo.tab_Users", new[] { "UserId", "UserName", "NickName", "UserPhoto" }, request.ListOfUserIds);

        if (result.Count > 0)
        {
            return new ApiResponse<List<GetuserDetailsRspDto>> { Data = result, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }

        return new ApiResponse<List<GetuserDetailsRspDto>>();
    }

    public async Task<ApiResponse<UserDetailDto>> GetSingleUserDetailsAsync(Guid RowId, CancellationToken cancellationToken = default)
    {
        #region ...

        // Check Exisit Record
        //Expression<Func<LoginInUserEntity, bool>> predicate = user => user.UserId == reqest.UserId;



        #region Predicate Filter
        Expression<Func<UserDetailsEntity, bool>> predicate = user => user.IsActive && user.RowId == RowId;
        #endregion

        var exist = await GetAvailablePredicateAsync(predicate, cancellationToken);
        if (exist != null)
        {
            #region Get Data Based on Filter from Database
            if (predicate != null)
            {
                var response = GetAll(predicate, cancellationToken);
                if (response != null)
                {
                    var lst = response.Select(x => new UserDetailDto
                    {
                        Id = x.Id,
                        UserId = Convert.ToInt32(x.UserId),
                        UserName = x.UserName,
                        NickName = x.NickName,
                        UserPhoto = x.UserPhoto,
                        RowId = x.RowId,

                    }).FirstOrDefault();
                    if (lst != null)
                    {
                        return new ApiResponse<UserDetailDto> { Data = lst, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
                    }
                    else
                    {
                        return new ApiResponse<UserDetailDto> { Data = lst, Code = ApiCodeEnum.Failed, MsgCode = ApiMessageEnum.Failed };
                    }

                }
            }
            #endregion
        }
        #region Default Response
        return new ApiResponse<UserDetailDto>();
        #endregion

        #endregion
    }

    public async Task<ApiResponse<List<UserDetailDto>>> GetUserDetailsAsync(GetUserReqDto? reqDto)
    {
        var response = GetAll();

        if (response != null)
        {
            List<object> userList =
            [
                .. response.Select(userDetails => (object)userDetails),
            ];

            #region PushUserDetailsToRedis
            // var redis = RedisService.PushListObjectToCache(CommonCacheKey.cacheKey_users_usersdetails, userList); 
            // var redis = await RedisService2.PushOrReplaceObject(CommonCacheKey.cacheKey_users_usersdetails, userList, "UserId");
            var redis = await RedisService2.PushOrReplaceObjectList(CommonCacheKey.cacheKey_users_usersdetails, userList, "UserId");
            #endregion

            var responseResult = response.Select(x => new UserDetailDto
            {
                Id = x.Id,
                UserName = x.UserName,
                NickName = x.NickName,
                UserPhoto = x.UserPhoto,
                RowId = x.RowId,
                UserId = Convert.ToInt32(x.UserId),
            }).ToList();

            return new ApiResponse<List<UserDetailDto>> { Data = responseResult, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };

        }
        return new ApiResponse<List<UserDetailDto>>();

    }

    public async Task<ApiResponse<bool>> UpdateUserAsync(UpdateUserReqDto reqest)
    {
        Expression<Func<UserDetailsEntity, bool>> predicate = user => user.RowId == reqest.RowId;

        var exist = await GetAvailablePredicateAsync(predicate);
        if (exist != null)
        {
            exist.UserName = reqest.UserName;
            exist.NickName = reqest.NickName;
            exist.UserPhoto = reqest.UserPhoto;
            exist.ModifiedBy = exist.UserId;
            exist.UtcDateModified = DateTime.UtcNow;
            var response = await UpdateAsync(exist, Convert.ToInt64(exist.UserId));
            if (response != null && response.Code != null && (int)response.Code == (int)DbCodeEnums.Success)
            {
                return new ApiResponse<bool> { Data = true, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
            }
        }

        return new ApiResponse<bool> { Data = false };

    }
}
