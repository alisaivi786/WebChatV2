#region NameSpace
using WebChat.Redis;

namespace WebChat.API.Controllers.Message;
#endregion

#region MessageController
#region Controller Attribute
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Message")]
[ApiController]
#endregion
public class MessageController(IUnitOfWork unitOfWork, IWebHostEnvironment environment, IRedisService RedisService) : ControllerBase
{
    #region UnitOfWork Container
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    #endregion

    #region WebHostEnvironment
    private readonly IWebHostEnvironment _environment = environment;
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

    #region UploadImage
    [MapToApiVersion(1)]
    [HttpPost("UploadImage")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return StatusCode(400, new { Errno = 1, Message = "No file uploaded." });
        }

        try
        {
            var contentRoot = _environment.ContentRootPath;
            // var uploadsFolder = Path.Combine(contentRoot, "Uploads");
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "Uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName.Replace(" ", "_").Trim();
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Uploads/{uniqueFileName}";

            var result = new
            {
                Errno = 0,
                Data = new
                {
                    Url = imageUrl,
                    alt = file.FileName.Replace(" ", "_"),
                    Href = ""
                }
            };

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Errno = 1, ex.Message });
        }
    }
    #endregion

    #region GetMessageDetailsRedis
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
    [HttpPost("GetMessageDetailsRedis")]
    public async Task<IActionResult> GetMessageDetailsRedis(GetMessageReqDtoRedis reqest)
    {
        var response = await RedisService.GetAllRecords(reqest.GroupId);
        return Ok(response);
    }
    #endregion
}
#endregion