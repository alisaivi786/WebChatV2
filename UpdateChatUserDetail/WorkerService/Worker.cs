#region NameSpace
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using System.Collections.Generic;
using WebChat.Application.ApplicationSettings;
using WebChat.Common.Dto.RequestDtos.User;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.Common.Dto.ResponseDtos.Users;
using WebChat.Presistence.Ado;
using WebChat.Redis;

namespace UpdateChatUserDetail.WorkerService; 
#endregion

#region Worker
#region Worker Summary
/// <summary>
/// Worker
/// Developer: ALI RAZA MUSHTAQ
/// Date: 22-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="logger"></param> 
#endregion
internal class Worker(
    IRedisService RedisService,
    ILogger<Worker> logger,
    IAppSettings appSettings
    ) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly IRedisService RedisService = RedisService;
    private readonly IAppSettings appSettings = appSettings;

    #region ExecuteAsync
    #region ExecuteAsync Summary
    /// <summary>
    /// ExecuteAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 22-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns> 
    #endregion
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken); // Simulate some work

            // Uncomment the line below if you want to perform some background processing.
            // Your actual background processing logic should go here.
            await DoBackgroundWorkWithCode(stoppingToken);
        }
    }
    #endregion

    #region DoBackgroundWork Directly with Code Logic
    #region DoBackgroundWork Summary
    /// <summary>
    /// DoBackgroundWork
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 22-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary> 
    #endregion
    private async Task DoBackgroundWorkWithCode(CancellationToken stoppingToken)
    {
        // Your background processing logic goes here
        _logger.LogInformation("Back Groud Worker running at: {time}", DateTimeOffset.Now);

        try
        {
            // Write code....
            var list = await RedisService.GetUserIds();
            _logger.LogInformation("Get User Id From Redis Server: {UserIds}", list);
            // Call Database Lottery and Get User Data:

            // Call Lottery DB to Authenticate the Users:
            using AdoNetDatabase<LoginReqDTO> database = new(appSettings);
            var lotteryResponse = database.GetRows<LotteryUserDetailsRspDto>("lottery.dbo.VW_Chat_User_Details", ["UserId", "UserName", "NickName", "UserPhoto"], $"UserId IN ({string.Join(", ", list)})");
            // Log the lotteryResponse as JSON
            _logger.LogInformation("Get User Details From Lottery DB: {UserDetails}", JsonConvert.SerializeObject(lotteryResponse));

            RedisService.RemoveKey(CommonCacheKey.cacheKey_users_usersdetails);

            RedisService.PushObjectList(CommonCacheKey.cacheKey_users_usersdetails, lotteryResponse);


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    #endregion
}
#endregion