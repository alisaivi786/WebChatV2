#region NameSpace
namespace QueueToDatabaseService.WorkerService; 
#endregion

#region Worker
#region Worker Summary
/// <summary>
/// Worker
/// Developer: ALI RAZA MUSHTAQ
/// Date: 08-Feb-2024
/// alisaivi786@gmail.com
/// </summary>
/// <param name="logger"></param> 
#endregion
internal class Worker(ILogger<Worker> logger) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;

    #region ExecuteAsync
    #region ExecuteAsync Summary
    /// <summary>
    /// ExecuteAsync
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
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
            DoBackgroundWork();
        }
    }
    #endregion

    #region DoBackgroundWork
    #region DoBackgroundWork Summary
    /// <summary>
    /// DoBackgroundWork
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary> 
    #endregion
    private void DoBackgroundWork()
    {
        // Your background processing logic goes here
        _logger.LogInformation("Back Groud Worker running at: {time}", DateTimeOffset.Now);
    }
    #endregion
} 
#endregion