using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using WebChat.Common.Dto.RequestDtos.Tests;
using WebChat.Common.Dto.ResponseDtos.LotteryUsers;

namespace WebChat.API.Controllers;

/// <summary>
/// Test Controller
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 13-02-2024
/// </summary>
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Test")]
[ApiController]
public class TestController(IRedisService RedisService, IRedisService2<GetuserDetailsRspDto> RedisService2) : ControllerBase
{
    #region ChatHubTest
    [MapToApiVersion(1)]
    [HttpPost("ChatHubTest")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> ChatHubTest(ChatHubTestReq request)
    {
        // const int numberOfRecords = 1;
        request.NumberOfRecords = request.NumberOfRecords ?? 10;

        var hubConnection = new HubConnectionBuilder()
           .WithUrl("https://localhost:7285/chatHub")
           .WithAutomaticReconnect()
           .Build();

        await hubConnection.StartAsync();

        #region Run the test
        for (int i = 0; i < request.NumberOfRecords; i++)
        {
            var message = GetTestMessage(i);
            await hubConnection.InvokeAsync("SendMessageAsync", message);

            await Task.Delay(200);
        }
        #endregion

        await hubConnection.StopAsync();

        return Ok();
    }
    #endregion

    #region GetTestMessage
    private string GetTestMessage(int index)
    {
        return JsonConvert.SerializeObject(new { SubGroupId = 1, SubGroupName = "10 Minute", UserId = 500, UserName = "MemberNNGY4OQB", Message = $"Test Message [{index + 1}]", Time = DateTime.UtcNow, UUID = Guid.NewGuid() });
        //return JsonConvert.SerializeObject(new
        //{
        //    SubGroupId = 1,
        //    SubGroupName = "10 Minute",
        //    UserId = 501,
        //    UserName = "MemberNNGY4OQB",
        //    Message = $"Test Message [1]",
        //    Time = "2024-02-16 09:37:08.909730",
        //    UUID = "1234"
        //});

        //   var json = "{\"MessageId\":0,\"UserId\":3,\"UserName\":\"Aymen\",\"SubGroupId\":1,\"SubGroupName\":\"Test group\",\"GroupId\":null,\"GroupName\":null,\"Message\":\"<p><img src=\\\"https://localhost:7285/Uploads/cb67de92-26ae-42dd-93dd-52fc9bfb2ad3_Group_Chat_App_Main_Flow.jpg\\\" alt=\\\"Group_Chat_App_Main_Flow.jpg\\\" data-href=\\\"\\\" style=\\\"width: 83.00px;height: 117.31px;\\\"/></p>\",\"Time\":\"2024-02-14T12:09:49.338\",\"UUID\":\"f4e115fa-fa14-4677-a6fa-1d9d19c859de\"}";

        //   return json;
    }
    #endregion

    #region PushUserDetailsToRedis
    [MapToApiVersion(1)]
    [HttpPost("PushUserDetailsToRedis")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> PushUserDetailsToRedis(GetuserDetailsRspDto request)
    {
        var userDetailsJson = JsonConvert.SerializeObject(request);

        await RedisService2.PushOrReplaceObject(WebChat.Redis.CommonCacheKey.cacheKey_users_usersdetails2, request, "UserId");
        // RedisService.PushJsonObjectToRedisAsync(userDetailsJson, WebChat.Redis.CommonCacheKey.cacheKey_users_usersdetails);

        // RedisService.RemoveKey(WebChat.Redis.CommonCacheKey.cacheKey_users_usersdetails2);

        return Ok();
    }
    #endregion

    #region PushUsersDetailsListToRedis
    [MapToApiVersion(1)]
    [HttpPost("PushUsersDetailsListToRedis")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> PushUsersDetailsListToRedis(List<GetuserDetailsRspDto> request)
    {
        var userDetailsJson = JsonConvert.SerializeObject(request);

        //  RedisService.PushObjectList(WebChat.Redis.CommonCacheKey.cacheKey_users_usersdetails2 , request);
        // RedisService.RemoveKey(WebChat.Redis.CommonCacheKey.cacheKey_users_usersdetails2);

        RedisService.PushJsonObjectToRedisAsync(userDetailsJson, WebChat.Redis.CommonCacheKey.cacheKey_users_usersdetails2);

        return Ok();
    }
    #endregion

    #region GetUserDetailsFromRedis
    [MapToApiVersion(1)]
    [HttpPost("GetUserDetailsFromRedis")]
    [SwaggerResponse((int)ApiCodeEnum.Success, "Back parameter comments", typeof(ApiResponse<bool>))]
    public async Task<IActionResult> GetUserDetailsFromRedis()
    {
        var usersDetails = await RedisService.GetAllUsersDetails();
        // var usersDetails = await RedisService.GetAllUsersDetails2();

        // var uuid = await RedisService.GetLastMessageUUID("[1]");

        return Ok(usersDetails);
    }
    #endregion
}