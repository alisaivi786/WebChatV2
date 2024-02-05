using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Domain.Entities;

namespace WebChat.RabbitMQ;

public class RabbitMQConsumer(ConnectionFactory connectionFactory, IUnitOfWork unitOfWork) : IRabbitMQConsumer
{
    private readonly ConnectionFactory factory = connectionFactory;

    private readonly IUnitOfWork unitOfWork = unitOfWork;

    #region StartConsuming
    public async Task StartConsuming()
    {
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        var connection = factory.CreateConnection();

        //Here we create channel with session and model

        var channel = connection.CreateModel();

        //declare the queue after mentioning name and a few property related to that
        channel.QueueDeclare(queue: "chat_queue",
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"Start Consuming Message: {message}");


            var messageJson = JsonConvert.DeserializeObject<dynamic>(message);

            var messageEntity = JsonConvert.DeserializeObject<MessageEntity>(messageJson);

           //  var response = await unitOfWork.MessageRepository.AddAsync(messageEntity);
        };

        channel.BasicConsume(queue: "chat_queue",
                              autoAck: true,
                              consumer: consumer);
    }

    public void StartConsuming(Action<string> onMessageReceived)
    {
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        var connection = factory.CreateConnection();

        //Here we create channel with session and model

        var channel = connection.CreateModel();

        //declare the queue after mentioning name and a few property related to that
        channel.QueueDeclare(queue: "chat_queue",
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"Start Consuming Message: {message}");

            // ***********
            // Sync message to SQL Database using Entity Framework Core
            //************
        };

        channel.BasicConsume(queue: "chat_queue",
                              autoAck: true,
                              consumer: consumer);
    }
    #endregion
}