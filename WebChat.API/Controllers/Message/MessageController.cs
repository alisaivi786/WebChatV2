#region NameSpace
using System.Collections.Generic;
using WebChat.Common.Dto.ResponseDtos.Users;
using WebChat.Redis;
using WebChat.Redis.RedisHelper;

namespace WebChat.API.Controllers.Message;
#endregion

#region MessageController
#region Controller Attribute
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Message")]
#endregion
public class MessageController(
    IRedisService2<MessageDetailDto> RedisService2,
    IUserDetailsService userDetailsService) : BaseAuthController
{
    #region GetMessageDetails
    [MapToApiVersion(1)]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<PageBaseDataResponse<List<MessageDetailDto>>>))]
    [HttpPost("GetMessages")]
    public async Task<IActionResult> GetMessageDetails(GetMessageReqDto request)
    {
        var roomId = $"[{request.SubGroupId}]";
        var pagedList = new PageBaseResponse<List<MessageDetailDto>>();
        var response = new ApiResponse<PageBaseResponse<List<MessageDetailDto>>>();

        var redisKey = string.Format(CommonCacheKey.chatroom, roomId);

        #region Check if redis is empty reead from db and push to redis
        var count = await RedisService2.GetRedisCountAsync(redisKey);

        if (count == 0)
        {
            request.PageSize = Convert.ToInt32(AppSettings.RedisCharRoomLimit ?? "1000");

            var dbMessagesList = await UnitOfWork.MessageRepository.GetMessageDetailsAsync(request, int.MaxValue);

            // await RedisService.PushMessagesList(dbMessagesList.Data.List, roomId);
            await RedisService2.PushObjectListAsync(redisKey, dbMessagesList.Data.List);
        }
        #endregion

        if (request.PageNo - 1 == 0)
        {
            var list = await RedisService2.GetRedisListAsync(redisKey);

            var mappedList = await userDetailsService.MapUsersDetailsListAsync(CommonCacheKey.cacheKey_users_usersdetails, list);

            if (list.Count > 0)
            {
                var result = new PageBaseResponse<List<MessageDetailDto>>()
                {
                    List = [.. mappedList.OrderByDescending(x => x.MessageId).ThenByDescending(x => x.Time)],
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

            var lastMessageId = lastMessage.Data?.MessageId ?? long.MaxValue;

            pagedList = await UnitOfWork.MessageRepository.GetMessageDetailsListAsync(request, lastMessageId);

            #region Map User Name from Redis User Details to Message Details
            var mappedList = await userDetailsService.MapUsersDetailsListAsync(CommonCacheKey.cacheKey_users_usersdetails, pagedList.List);


            var result = new PageBaseResponse<List<MessageDetailDto>>()
            { List = mappedList.OrderByDescending(x => x.MessageId).ThenByDescending(x => x.Time).ToList(), PageNo = pagedList?.PageNo, TotalPage = pagedList?.TotalPage, TotalCount = pagedList?.TotalCount };
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
}
#endregion