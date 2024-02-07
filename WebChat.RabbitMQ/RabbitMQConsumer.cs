using Amazon.Runtime.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Common.Dto.RequestDtos.Message;

namespace WebChat.RabbitMQ;

public class RabbitMQConsumer : IRabbitMQConsumer
{
    private ConnectionFactory factory;
    private IServiceScopeFactory _serviceScopeFactory;
    private IServiceScope scope;
    private IUnitOfWork unitOfWork;
    //private  IMessageRepository messageRepository;
    //private  WebchatDBContext _context;
    //private  IConfiguration? _configuration;
    //private  IHttpContextAccessor? _httpContextAccessor;
    //private  AppSettings _applicationSettings;
    public RabbitMQConsumer(ConnectionFactory connectionFactory, IServiceScopeFactory serviceScopeFactory)
    {
        factory = connectionFactory;
        _serviceScopeFactory = serviceScopeFactory;
        scope = _serviceScopeFactory.CreateScope();
        unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        //_context = scope.ServiceProvider.GetRequiredService<WebchatDBContext>();
        //_applicationSettings = scope.ServiceProvider.GetRequiredService<AppSettings>();
        //messageRepository = scope.ServiceProvider.GetRequiredService<IMessageRepository>();
        //unitOfWork = new UnitOfWork(context: _context, configuration: _configuration, httpContextAccessor: _httpContextAccessor, applicationSettings: _applicationSettings);
    }

    #region StartConsuming
    public async Task StartConsuming()
    {
        var connection = factory.CreateConnection();
        Console.WriteLine("RabbitMQ Connection Established");

        var channel = connection.CreateModel();

        try
        {
            channel.QueueDeclare(queue: "chat_queue",
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                Console.WriteLine("Message Reciving");

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Start Consuming Message: {message}");


                var messageJson = JsonConvert.DeserializeObject<dynamic>(message);

                var messageEntity = JsonConvert.DeserializeObject<AddMessageReqDto>(messageJson);

                scope = _serviceScopeFactory.CreateScope();
                unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                //_context = scope.ServiceProvider.GetRequiredService<WebchatDBContext>();
                //_applicationSettings = scope.ServiceProvider.GetRequiredService<AppSettings>();
                //messageRepository = scope.ServiceProvider.GetRequiredService<IMessageRepository>();
                //unitOfWork = new UnitOfWork(context: _context, configuration: _configuration, httpContextAccessor: _httpContextAccessor, applicationSettings: _applicationSettings);

                var response = await unitOfWork.MessageRepository.AddMessageAsync(messageEntity);

            };

            channel.BasicConsume(queue: "chat_queue",
                                  autoAck: true,
                                  consumer: consumer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error declaring queue: {ex.Message}");
        }
    }
    #endregion

    private IUnitOfWork GetUnitOfWork()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        // Use unitOfWork for database operations

        return unitOfWork;
    }
}