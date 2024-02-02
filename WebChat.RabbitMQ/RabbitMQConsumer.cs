using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WebChat.Application.ApplicationSettings;

namespace WebChat.RabbitMQ;

public class RabbitMQConsumer(ConnectionFactory connectionFactory) : IRabbitMQConsumer
{
    private readonly ConnectionFactory factory = connectionFactory;

    #region StartConsuming
    public void StartConsuming()
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
