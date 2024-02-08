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

    #region Constructor Initialization 
    public RabbitMQConsumer(ConnectionFactory connectionFactory, IServiceScopeFactory serviceScopeFactory)
    {
        factory = connectionFactory;
        _serviceScopeFactory = serviceScopeFactory;
        scope = _serviceScopeFactory.CreateScope();
        unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
    }
    #endregion

    #region StartConsuming
    public async Task StartConsuming(string queueName)
    {
        var connection = factory.CreateConnection();
        Console.WriteLine("RabbitMQ Connection Established");

        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: queueName,
              durable: false,
              exclusive: false,
              autoDelete: false,
              arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            Console.WriteLine("Message Receiving");

            var body = ea.Body.ToArray();
            var messageJson = Encoding.UTF8.GetString(body);

            var message = JsonConvert.DeserializeObject<AddMessageReqDto>(messageJson);


            #region Sync with Database
            scope = _serviceScopeFactory.CreateScope();
            unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var response = await unitOfWork.MessageRepository.AddMessageAsync(message);
            #endregion
        };

        channel.BasicConsume(queue: queueName,
                              autoAck: true,
                              consumer: consumer);
    }
    #endregion
}