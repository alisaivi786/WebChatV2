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
                .UseWindowsService()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    //config.SetBasePath(Directory.GetCurrentDirectory());
                    //config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
                    config.AddJsonFile(Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "appsettings.json"), optional: true, reloadOnChange: true);

                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpContextAccessor();
                    services.AddHostedService<Worker>();
                    // Load configuration
                    var configuration = hostContext.Configuration;
                    var AppSetting = new AppSettings(configuration);
                    Console.WriteLine("DBProvider" + AppSetting.MySqlConnectionString);
                    // Add AppSettings as a singleton service and pass the configuration to the constructor
                    services.AddSingleton<IAppSettings>(AppSetting);
                    // Add Persistence Infrastructure
                    services.AddPersistenceInfrastructure(AppSetting);
                    // Add Rabbit MQ
                    services.AddRegisterRabbitMQ(AppSetting);
                    // Add Redis
                    services.AddRegisterRedis();

                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddEventLog();
                });

    #endregion 
    #endregion
}
#endregion


