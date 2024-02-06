#region NameSpace
namespace WebChat.API.Controllers; 
#endregion

[Route("api/[controller]")]
[ApiController]
public class GroupController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<GroupDetailRspDto>>>))]
    [HttpPost("GetGroup")]
    public async Task<IActionResult> GetGroupDetails(GetGroupReqDto reqest)
    {
        var response = await unitOfWork.GroupRepository.GetGroupDetailsAsync(reqest);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<GroupDetailRspDto>))]
    public async Task<IActionResult> Get(int id)
    {
        var response = await unitOfWork.GroupRepository.GetSingleGroupDetailsAsync(id);
        return Ok(response);
    }

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

    [HttpPost("DeleteGroup")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Delete(DeleteGroupReqDto request)
    {
        var response = await unitOfWork.GroupRepository.DeleteGroupAsync(request);
        return Ok(response);
    }
}
