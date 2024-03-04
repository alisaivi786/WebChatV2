#region NameSpace
using Microsoft.Extensions.Configuration;
using System.Text;
using WebChat.RabbitMQ;

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
internal class Worker(
    ILogger<Worker> logger,
    IRabbitMQConsumer RabbitMQConsumer,
    IConfiguration configuration
    ) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly IConfiguration configuration = configuration;
    private readonly IRabbitMQConsumer RabbitMQConsumer = RabbitMQConsumer;

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
            await Task.Delay(5000, stoppingToken); // Simulate some work

            // Uncomment the line below if you want to perform some background processing.
            // Your actual background processing logic should go here.

            await DoBackgroundWorkWithCode(stoppingToken);
            // await DoBackgroundWorkWithApiCall(stoppingToken);
        }
    }
    #endregion

    #region DoBackgroundWork Via API
    #region DoBackgroundWork Summary
    /// <summary>
    /// DoBackgroundWork
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary> 
    #endregion
    private async Task DoBackgroundWorkWithApiCall(CancellationToken stoppingToken)
    {
        // Your background processing logic goes here
        _logger.LogInformation("Back Groud Worker running at: {time}", DateTimeOffset.Now);

        try
        {
            string baseUrl = configuration["WebChatAPI:BaseURL"];

            using HttpClient httpClient = new();

            // Send an empty JSON object as the request body
            StringContent emptyJsonContent = new("{}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(baseUrl, emptyJsonContent);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    #endregion

    #region DoBackgroundWork Directly with Code Logic
    #region DoBackgroundWork Summary
    /// <summary>
    /// DoBackgroundWork
    /// Developer: ALI RAZA MUSHTAQ
    /// Date: 08-Feb-2024
    /// alisaivi786@gmail.com
    /// </summary> 
    #endregion
    private async Task DoBackgroundWorkWithCode(CancellationToken stoppingToken)
    {
        // Your background processing logic goes here
        _logger.LogInformation("Back Groud Worker running at: {time}", DateTimeOffset.Now);

        try
        {
            await RabbitMQConsumer.StartConsuming(queueNamePattern: "destination_queue_*");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    #endregion
}
#endregion