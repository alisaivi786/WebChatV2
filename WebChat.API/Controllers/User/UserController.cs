using WebChat.Presistence.UnitOfWork;

namespace WebChat.API.Controllers.User;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/User")]
public class UserController(IRedisService RedisService) : BaseAuthController
{
    private readonly IRedisService RedisService = RedisService;

    #region GetUserDetails
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
    [HttpPost("GetLotteryUsers")]
    public async Task<IActionResult> GetUsersDetails(GetUserDetailsReqDto request)
    {
        Log.Information("API endpoint accessed: POST /api/v1/User/GetLotteryUsers");

        var cu = CurrentUser.UserId.ToString();

        // Specify your JSON file name
        string fileName = "tab_Users(10000 Rows).json";
        //GetUserDetailsReqDto request = new();
        //request.ListOfUserIds = await jsonFileService.GetItemsFromJsonFile(fileName);

        var response = await UnitOfWork.UserRepository.GetLotteryUserDetailsAsync(request);

        return Ok(response);
    }

    #endregion

    #region GetUserDetails
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<UserDetailDto>>>))]
    [HttpPost("GetUserDetails")]
    public async Task<IActionResult> GetUserDetails(GetUserReqDto reqest)
    {
        #region ...
        var response = await UnitOfWork.UserRepository.GetUserDetailsAsync(reqest);
        return Ok(response);
        #endregion
    }
    #endregion

    #region GetCurrentUserDetails
    //[Authorize]
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
    [HttpPost("GetCurrentUserDetails")]
    public async Task<IActionResult> GetCurrentUserDetails(UserDetailsReq request)
    {
        var response = await UnitOfWork.UserRepository.GetSingleUserDetailsAsync(request.UUID);
        return Ok(response);
    }

    #endregion

    #region GetRedisUsersId
    [MapToApiVersion(1)]
    [HttpPost("GetRedisUsersId")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> GetRedisUsersId()
    {
        var list = await RedisService.GetUserIds();

        return Ok(list);
    }
    #endregion

    #region UpdateUserDetails
    [MapToApiVersion(1)]
    [HttpPost("UpdateUserDetails")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> UpdateUserDetails([FromBody] UpdateUserReqDto reqest)
    {
        var response = await UnitOfWork.UserRepository.UpdateUserAsync(reqest);
        return Ok(response);
    }
    #endregion
}

