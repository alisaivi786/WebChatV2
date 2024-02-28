
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace WebChat.RabbitMQ;

/// <summary>
/// RabbitMQProducer Class
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 01-02-2024
/// </summary>
public class RabbitMQProducer(ConnectionFactory connectionFactory) : IRabbitMQProducer
{
    private readonly ConnectionFactory factory = connectionFactory;

    #region PublishMessageToRabbitMQ
    /// <summary>
    /// PublishMessageToRabbitMQ
    /// </summary>
    /// <param name="message"></param>
    /// <param name="queueName"></param>
    /// <returns>void</returns>
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
    #endregion

    #region PublishMessageToRabbitMQAcks
    /// <summary>
    /// PublishMessageToRabbitMQAcks
    /// </summary>
    /// <param name="message"></param>
    /// <param name="queueName"></param>
    /// <returns>void</returns>
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
                Console.WriteLine("--> PublishMessageToRabbitMQAcks: Message delivered successfully.");
                // Handle successful delivery
            };
            channel.BasicNacks += (sender, args) =>
            {
                Console.WriteLine("--> PublishMessageToRabbitMQAcks: Message delivery failed.");
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
                Console.WriteLine("--> PublishMessageToRabbitMQAcks: Message delivery confirmation not received.");
                // Handle the case where confirmation wasn't received within the timeout
            }
        }
    }
    #endregion

    #region TimedPublishMessageToRabbitMQ
    /// <summary>
    /// TimedPublishMessageToRabbitMQ
    /// </summary>
    /// <param name="message"></param>
    /// <param name="sourceQueue"></param>
    /// <param name="destinationQueue"></param>
    /// <param name="groupId"></param>
    /// <returns>void</returns>
    public void TimedPublishMessageToRabbitMQ<T>(T message, string sourceQueue, string destinationQueue, string? groupId = null)
    {
        int messageTtlMilliseconds = 10000; // 10 seconds

        string DLXExchangeName = $"dlx_exchange{groupId}";

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            var queueArgs = new Dictionary<string, object>
            {
                {"x-message-ttl", messageTtlMilliseconds},
                {"x-dead-letter-exchange", DLXExchangeName}
            };
            channel.QueueDeclare(sourceQueue, durable: true, exclusive: false, autoDelete: false, arguments: queueArgs);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = channel.CreateBasicProperties();
            properties.Expiration = $"{messageTtlMilliseconds}";

            channel.BasicPublish(exchange: "", routingKey: sourceQueue, basicProperties: properties, body: body);

            channel.QueueDeclare(destinationQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.ExchangeDeclare(DLXExchangeName, ExchangeType.Topic);

            channel.QueueBind(destinationQueue, DLXExchangeName, "#");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());

                    Console.WriteLine($"--> Message Received {message}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message: {ex.Message}");
                }

            };

            // channel.BasicConsume(DLQQueueName, autoAck: true, consumer: consumer);
        }
    }
    #endregion

    #region TimedPublishMessageToRabbitMQAcks
    /// <summary>
    /// TimedPublishMessageToRabbitMQAcks
    /// </summary>
    /// <param name="message"></param>
    /// <param name="sourceQueue"></param>
    /// <param name="destinationQueue"></param>
    /// <param name="groupId"></param>
    /// <returns>void</returns>
    public void TimedPublishMessageToRabbitMQAcks<T>(T message, string sourceQueue, string destinationQueue, string? groupId = null)
    {
        int messageTtlMilliseconds = 10000; // 10 seconds

        string DLXExchangeName = $"dlx_exchange{groupId}";

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            var queueArgs = new Dictionary<string, object>
            {
                {"x-message-ttl", messageTtlMilliseconds},
                {"x-dead-letter-exchange", DLXExchangeName}
            };

            #region Acks
            // Enable publisher confirms
            channel.ConfirmSelect();

            // Set up a callback for confirms
            channel.BasicAcks += (sender, args) =>
            {
                Console.WriteLine("--> TimedPublishMessageToRabbitMQAcks: Message delivered to source queue successfully.");
                // Handle successful delivery
            };
            channel.BasicNacks += (sender, args) =>
            {
                Console.WriteLine("--> TimedPublishMessageToRabbitMQAcks: Message delivery to source queue failed.");
                // Handle delivery failure
            };
            #endregion

            channel.QueueDeclare(sourceQueue, durable: true, exclusive: false, autoDelete: false, arguments: queueArgs);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = channel.CreateBasicProperties();
            properties.Expiration = $"{messageTtlMilliseconds}";

            channel.BasicPublish(exchange: "", routingKey: sourceQueue, basicProperties: properties, body: body);

            #region Wait for the confirms
            if (!channel.WaitForConfirms(TimeSpan.FromSeconds(10)))
            {
                // Handle the case where confirmation wasn't received within the timeout
                Console.WriteLine("--> TimedPublishMessageToRabbitMQAcks: Message delivery confirmation not received.");
            }
            #endregion

            channel.QueueDeclare(destinationQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);
            channel.ExchangeDeclare(DLXExchangeName, ExchangeType.Topic);

            channel.QueueBind(destinationQueue, DLXExchangeName, "#");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());

                    Console.WriteLine($"--> TimedPublishMessageToRabbitMQAcks: Message Received {message}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> TimedPublishMessageToRabbitMQAcks: Error processing message: {ex.Message}");
                }

            };

            // channel.BasicConsume(DLQQueueName, autoAck: true, consumer: consumer);
        }
    }
    #endregion
}
