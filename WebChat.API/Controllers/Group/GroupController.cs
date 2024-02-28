#region NameSpace
namespace WebChat.API.Controllers.Group;
#endregion

#region GroupController
#region Attr
[ApiVersion("1")]
[Route("api/v{version:apiVersion}")]
#endregion
public class GroupController(IUnitOfWork unitOfWork) : BaseAuthController
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    #region GetGroupDetailsV1
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<GroupDetailRspDto>>>))]
    [HttpPost("GetGroup")]
    public async Task<IActionResult> GetGroupDetailsV1(GetGroupReqDto reqest)
    {
        #region ...
        var response = await unitOfWork.GroupRepository.GetGroupDetailsAsync(reqest);
        return Ok(response);
        #endregion
    }
    #endregion

    #region Group-Id
    [HttpGet("Group-Id/{id}")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<GroupDetailRspDto>))]
    public async Task<IActionResult> Get(int id)
    {
        #region ...
        var response = await unitOfWork.GroupRepository.GetSingleGroupDetailsAsync(id);
        return Ok(response);
        #endregion
    }
    #endregion

    #region AddGroup
    [HttpPost("AddGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Post([FromBody] AddGroupReqDto reqest)
    {
        #region ...
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await unitOfWork.GroupRepository.AddGroupAsync(reqest);
        return Ok(response);
        #endregion
    }
    #endregion

    #region UpdateGroup
    [HttpPost("UpdateGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Put([FromBody] UpdateGroupReqDto reqest)
    {
        #region ...
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var response = await unitOfWork.GroupRepository.UpdateGroupAsync(reqest);
        return Ok(response);
        #endregion
    }
    #endregion

    #region DeleteGroup
    [HttpPost("DeleteGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Delete(DeleteGroupReqDto request)
    {
        #region ...
        var response = await unitOfWork.GroupRepository.DeleteGroupAsync(request);
        return Ok(response);
        #endregion
    }
    #endregion

}

#endregion