using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using WebChat.Application.ApplicationSettings;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Common.Dto.RequestDtos.GroupUser;
using WebChat.Common.Dto.RequestDtos.Message;

namespace WebChat.RabbitMQ;

/// <summary>
/// RabbitMQConsumer Class
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 01-02-2024
/// </summary>
public class RabbitMQConsumer : IRabbitMQConsumer
{
    #region Declaring priavte fields
    private readonly ConnectionFactory factory;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IServiceScope scope;
    private readonly IUnitOfWork unitOfWork;
    private readonly IAppSettings AppSettings;
    private readonly ILogger<RabbitMQConsumer> logger;
    #endregion


    #region Constructor Initialization 
    /// <summary>
    /// RabbitMQConsumer Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="connectionFactory"></param>
    /// <param name="serviceScopeFactory"></param>
    /// <param name="appSettings"></param>
    /// <returns></returns>
    public RabbitMQConsumer(ILogger<RabbitMQConsumer> logger,ConnectionFactory connectionFactory, IServiceScopeFactory serviceScopeFactory, IAppSettings appSettings)
    {
        factory = connectionFactory;
        _serviceScopeFactory = serviceScopeFactory;
        scope = _serviceScopeFactory.CreateScope();
        unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        AppSettings = appSettings;
        this.logger = logger;
    }
    #endregion

    #region StartConsuming chat realated queue
    /// <summary>
    /// StartConsuming
    /// </summary>
    /// <param name="queueNamePattern"></param>
    /// <returns>Task</returns>
    public async Task StartConsuming(string queueNamePattern)
    {
        var connection = factory.CreateConnection();
        logger.LogInformation("RabbitMQ Connection Established running at: {time}", DateTimeOffset.Now);

        var channel = connection.CreateModel();

        var queueNames = GetQueueNamesMatchingPattern(queueNamePattern);

        foreach (var queueName in queueNames)
        {
            channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                logger.LogInformation("Message Receiving at: {time}", DateTimeOffset.Now);
                var body = ea.Body.ToArray();
                var messageJson = Encoding.UTF8.GetString(body);

                var message = JsonConvert.DeserializeObject<AddMessageReqDto>(messageJson);

                #region Sync with Database
                using var scope = _serviceScopeFactory.CreateScope();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var response = await unitOfWork.MessageRepository.AddMessageAsync(message);
                #endregion
            };

            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }

    #region GetQueueNamesMatchingPattern
    /// <summary>
    /// GetQueueNamesMatchingPattern
    /// </summary>
    /// <param name="queueNamePattern"></param>
    /// <returns>IEnumerable<string></returns>
    private IEnumerable<string> GetQueueNamesMatchingPattern(string queueNamePattern)
    {
        var httpClient = new HttpClient();
        var managementApiUrl = AppSettings.ManagementApiUrl;

        // var byteArray = Encoding.ASCII.GetBytes("test:test");
        var byteArray = Encoding.ASCII.GetBytes($"{AppSettings.RabbitMqUserName}:{AppSettings.RabbitMqPassword}");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

        var response = httpClient.GetStringAsync(managementApiUrl).Result;

        var queues = JsonConvert.DeserializeObject<List<QueueInfo>>(response);

        var matchingQueues = queues
            .Where(queue => Regex.IsMatch(queue.Name, queueNamePattern))
            .Select(queue => queue.Name);

        return matchingQueues;
    }
    #endregion

    #endregion

    #region StartConsumingDisconnectedUsers
    /// <summary>
    /// StartConsumingDisconnectedUsers
    /// </summary>
    /// <param name="queueName"></param>
    /// <returns>Task</returns>
    public async Task StartConsumingDisconnectedUsers(string queueName)
    {
        var connection = factory.CreateConnection();
        logger.LogInformation("DisconnectedUsers: RabbitMQ Connection Established at: {time}", DateTimeOffset.Now);
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            logger.LogInformation("Message Receiving at: {time}", DateTimeOffset.Now);
            var body = ea.Body.ToArray();
            var messageJson = Encoding.UTF8.GetString(body);

            var User = JsonConvert.DeserializeObject<DeleteGroupUserReqDto>(messageJson);

            #region Remove from the table
            // Implementation of Remove from UsersGroups will be here
            using var scope = _serviceScopeFactory.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var response = await unitOfWork.GroupUserRepository.DeleteGroupUserPredicateAsync(User);
            #endregion
        };

        channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);
    } 
    #endregion
}