namespace WebChat.API.Controllers.GroupUser;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}")]
public class GroupUserController(IUnitOfWork UnitOfWork) : BaseAuthController
{
    private readonly IUnitOfWork unitOfWork = UnitOfWork;

    #region GetGroupUserDetails
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<GroupUserDetailDto>>>))]
    [HttpPost("GetGroupUsers")]
    public async Task<IActionResult> GetGroupUserDetails(GetGroupUserReqDto reqest)
    {
        var response = await unitOfWork.GroupUserRepository.GetGroupUserDetailsAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region GetGroupUserById
    [HttpGet("GroupUser-Id/{id}")]
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Get(int id)
    {
        var response = await unitOfWork.GroupUserRepository.GetSingleGroupUserDetailsAsync(id);
        return Ok(response);
    }
    #endregion

    #region AddGroupUser
    [MapToApiVersion(1)]
    [HttpPost("AddGroupUser")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Post([FromBody] AddGroupUserReqDto reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await unitOfWork.GroupUserRepository.AddGroupUserAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region AddBulkGroupUser
    [MapToApiVersion(1)]
    [HttpPost("AddBulkGroupUser")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> AddBulkGroupUser([FromBody] List<AddBulkGroupUserReqDto> reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await unitOfWork.GroupUserRepository.AddBulkGroupUserAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region UpdateGroupUser
    [MapToApiVersion(1)]
    [HttpPost("UpdateGroupUser")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Put([FromBody] UpdateGroupUserReqDto reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await unitOfWork.GroupUserRepository.UpdateGroupUserAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region DeleteGroupUser
    [MapToApiVersion(1)]
    [HttpPost("DeleteGroupUser")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Delete(DeleteGroupUserReqDto request)
    {
        var response = await unitOfWork.GroupUserRepository.DeleteGroupUserAsync(request);
        return Ok(response);
    }
    #endregion

}
