#region NameSpace
namespace QueueToDatabaseService;
#endregion

#region Program
#region Program Summary
/// <summary>
/// Main Program to Start this QueueToDatabaseService
/// This Service Perform De Queue Message from Queue and Post to Database.
/// Developer: ALI RAZA MUSHTAQ
/// Date: 08-Feb-2024
/// alisaivi786@gmail.com
/// </summary> 
#endregion
internal class Program
{
    #region ...
    #region ...
    #region Main
    /// <summary>
    /// Main
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    #endregion 
    #endregion

    #region CreateHostBuilder
    #region CreateHostBuilder Summary
    /// <summary>
    /// CreateHostBuilder
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns> 
    #endregion
    private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()  // Use this line if you want to run as a Windows Service
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                });
    #endregion 
    #endregion
} 
#endregion


