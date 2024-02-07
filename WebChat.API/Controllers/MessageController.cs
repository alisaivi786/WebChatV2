#region NameSpace
namespace WebChat.API.Controllers;
#endregion

#region MessageController
#region Controller Attribute
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Message")]
[ApiController]
#endregion
public class MessageController(IUnitOfWork unitOfWork) : ControllerBase
{
    #region UnitOfWork Container
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    #endregion

    #region GetMessageDetails
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
    [HttpPost("GetMessages")]
    public async Task<IActionResult> GetMessageDetails(GetMessageReqDto reqest)
    {
        var response = await unitOfWork.MessageRepository.GetMessageDetailsAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region GetMessageById
    [HttpGet("{id}")]
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Get(int id)
    {
        var response = await unitOfWork.MessageRepository.GetSingleMessageDetailsAsync(id);
        return Ok(response);
    }
    #endregion

    #region AddMessage
    [MapToApiVersion(1)]
    [HttpPost("AddMessage")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Post([FromBody] AddMessageReqDto reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }

        var response = await unitOfWork.MessageRepository.AddMessageAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region AddBulkMessage
    [MapToApiVersion(1)]
    [HttpPost("AddBulkMessage")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> AddBulkMessage([FromBody] List<AddBulkMessageReqDto> reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }

        var response = await unitOfWork.MessageRepository.AddBulkMessageAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region UpdateMessage
    [MapToApiVersion(1)]
    [HttpPost("UpdateMessage")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Put([FromBody] UpdateMessageReqDto reqest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }
        var response = await unitOfWork.MessageRepository.UpdateMessageAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region DeleteMessage
    [MapToApiVersion(1)]
    [HttpPost("DeleteMessage")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Delete(DeleteMessageReqDto request)
    {
        var response = await unitOfWork.MessageRepository.DeleteMessageAsync(request);
        return Ok(response);
    }
    #endregion
} 
#endregion