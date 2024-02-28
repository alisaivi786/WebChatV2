#region NameSpace
using System.Collections.Generic;
using WebChat.Common.Dto.ResponseDtos.Users;
using WebChat.Redis;

namespace WebChat.API.Controllers.Message;
#endregion

#region MessageController
#region Controller Attribute
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Message")]
#endregion
public class MessageController(IRedisService RedisService) : BaseAuthController
{
    private readonly IRedisService RedisService = RedisService;

    #region GetMessageDetails
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
    [HttpPost("GetMessages")]
    public async Task<IActionResult> GetMessageDetails(GetMessageReqDto request)
    {
        var roomId = $"[{request.SubGroupId}]";
        var pagedList = new PageBaseResponse<List<MessageDetailDto>>();
        var response = new ApiResponse<PageBaseResponse<List<MessageDetailDto>>>();

        #region Check if redis is empty reead from db and push to redis
        var count = await RedisService.GetRedisCount(roomId);

        if (count == 0)
        {
            request.PageSize = Convert.ToInt32(AppSettings.RedisCharRoomLimit ?? "1000");

            var dbMessagesList = await UnitOfWork.MessageRepository.GetMessageDetailsAsync(request, int.MaxValue);

            await RedisService.PushMessagesList(dbMessagesList.Data.List, roomId);
        }
        #endregion

        if (request.PageNo - 1 == 0)
        {
            var list = await RedisService.GetAllRedisMessages(roomId);

            var mappedList = await RedisService.MapUsersDetailsList(list);

            if (list.Count > 0)
            {
                var result = new PageBaseResponse<List<MessageDetailDto>>()
                {
                    List = [.. mappedList.OrderByDescending(x => x.Time)],
                    PageNo = 1,
                    TotalPage = 1,
                    TotalCount = list.Count
                };

                response = new ApiResponse<PageBaseResponse<List<MessageDetailDto>>>
                {
                    Data = result,
                    Code = ApiCodeEnum.Success,
                    MsgCode = ApiMessageEnum.Success
                };
            }
        }

        if (response.Data == null)
        {
            if (request.PageNo != 1)
            {
                request.PageNo -= 1;
            }

            var lastMessage = await UnitOfWork.MessageRepository.GetSingleMessageDetailsByUUIDAsync(request.UUID);

            var lastMessageId = lastMessage.Data?.MessageId ?? 0;

            pagedList = await UnitOfWork.MessageRepository.GetMessageDetailsListAsync(request, lastMessageId);

            #region Map User Name from Redis User Details to Message Details
            var mappedList = await RedisService.MapUsersDetailsList(pagedList.List);

            var result = new PageBaseResponse<List<MessageDetailDto>>()
            { List = mappedList, PageNo = pagedList?.PageNo, TotalPage = pagedList?.TotalPage, TotalCount = pagedList?.TotalCount };
            #endregion

            response =
             new ApiResponse<PageBaseResponse<List<MessageDetailDto>>> { Data = result, Code = ApiCodeEnum.Success, MsgCode = ApiMessageEnum.Success };
        }

        return Ok(response);
    }
    #endregion

    #region GetMessageById
    [HttpGet("{id}")]
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Get(int id)
    {
        var response = await UnitOfWork.MessageRepository.GetSingleMessageDetailsAsync(id);
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

        var response = await UnitOfWork.MessageRepository.AddMessageAsync(reqest);
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

        var response = await UnitOfWork.MessageRepository.AddBulkMessageAsync(reqest);
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
        var response = await UnitOfWork.MessageRepository.UpdateMessageAsync(reqest);
        return Ok(response);
    }
    #endregion

    #region DeleteMessage
    [MapToApiVersion(1)]
    [HttpPost("DeleteMessage")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> Delete(DeleteMessageReqDto request)
    {
        var response = await UnitOfWork.MessageRepository.DeleteMessageAsync(request);
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
            var contentRoot = Environment.ContentRootPath;
            // var uploadsFolder = Path.Combine(contentRoot, "Uploads");
            var uploadsFolder = Path.Combine(Environment.WebRootPath, "Uploads");

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

    #region GetRedisMessages
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
    [HttpPost("GetRedisMessages")]
    public async Task<IActionResult> GetRedisMessages(GetMessageReqDtoRedis reqest)
    {
        var roomId = $"{reqest.GroupName}[{reqest.SubGroupId}]";

        var response = await RedisService.GetAllRedisMessages(roomId);
        return Ok(response);
    }
    #endregion
}
#endregion