
namespace WebChat.RabbitMQ;

/// <summary>
/// IRabbitMQProducer Interface
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 01-02-2024
/// </summary>
public interface IRabbitMQProducer
{
    public void PublishMessageToRabbitMQ<T>(T message, string queueName);
    public void PublishMessageToRabbitMQAcks<T>(T message, string queueName);
    public void TimedPublishMessageToRabbitMQ<T>(T message, string sourceQueue, string destinationQueue,string? groupId = null);
    public void TimedPublishMessageToRabbitMQAcks<T>(T message, string sourceQueue, string destinationQueue, string? groupId = null);
}
