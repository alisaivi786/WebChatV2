
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WebChat.RabbitMQ;

public class RabbitMQProducer(ConnectionFactory connectionFactory) : IRabbitMQProducer
{
    private readonly ConnectionFactory factory = connectionFactory;

    public void PublishMessageToRabbitMQ<T>(T message, string queueName)
    {
        var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: queueName,
                 durable: false,
                 exclusive: false,
                 autoDelete: false,
                 arguments: null);

        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
    }


    public void PublishMessageToRabbitMQAcks<T>(T message, string queueName)
    {
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            // Enable publisher confirms
            channel.ConfirmSelect();

            // Set up a callback for confirms
            channel.BasicAcks += (sender, args) =>
            {
                Console.WriteLine("Message delivered successfully.");
                // Handle successful delivery
            };
            channel.BasicNacks += (sender, args) =>
            {
                Console.WriteLine("Message delivery failed.");
                // Handle delivery failure
            };

            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: queueName, body: body);

            // Wait for the confirms
            if (!channel.WaitForConfirms(TimeSpan.FromSeconds(10)))
            {
                Console.WriteLine("Message delivery confirmation not received.");
                // Handle the case where confirmation wasn't received within the timeout
            }
        }
    }
}
