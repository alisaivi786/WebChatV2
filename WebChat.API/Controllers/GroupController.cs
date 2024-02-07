#region NameSpace
namespace WebChat.API.Controllers;
#endregion



[Route("api/v{version:apiVersion}/Group")]
[ApiController]
public class GroupController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [ApiVersion("2")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<GroupDetailRspDto>>>))]
    [HttpPost("GetGroupV2")]
    public async Task<IActionResult> GetGroupDetailsV2(GetGroupReqDto reqest)
    {
        if (!IsValidVersion("2"))
        {
            return Redirect("/api/v1/invalid-version");
        }
        var response = await unitOfWork.GroupRepository.GetGroupDetailsAsync(reqest);
        return Ok(response);
    }

    [ApiVersion("1")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<GroupDetailRspDto>>>))]
    [HttpPost("GetGroup")]
    public async Task<IActionResult> GetGroupDetailsV1(GetGroupReqDto reqest)
    {
        var response = await unitOfWork.GroupRepository.GetGroupDetailsAsync(reqest);
        return Ok(response);
    }

    [ApiVersion("1")]
    [HttpGet("{id}")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<GroupDetailRspDto>))]
    public async Task<IActionResult> Get(int id)
    {
        var response = await unitOfWork.GroupRepository.GetSingleGroupDetailsAsync(id);
        return Ok(response);
    }

    [ApiVersion("1")]
    [HttpPost("AddGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Post([FromBody] AddGroupReqDto reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }

        var response = await unitOfWork.GroupRepository.AddGroupAsync(reqest);
        return Ok(response);
    }

    [ApiVersion("1")]
    [HttpPost("UpdateGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Put([FromBody] UpdateGroupReqDto reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }
        var response = await unitOfWork.GroupRepository.UpdateGroupAsync(reqest);
        return Ok(response);
    }

    [ApiVersion("1")]
    [HttpPost("DeleteGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Delete(DeleteGroupReqDto request)
    {
        var response = await unitOfWork.GroupRepository.DeleteGroupAsync(request);
        return Ok(response);
    }

    private bool IsValidVersion(string expectedVersion)
    {
        var apiVersion = HttpContext.GetRequestedApiVersion().ToString();
        return apiVersion == expectedVersion;
    }
}
