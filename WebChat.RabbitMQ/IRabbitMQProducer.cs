
namespace WebChat.RabbitMQ;

public interface IRabbitMQProducer
{
    public void PublishMessageToRabbitMQ<T>(T message, string queueName);
    public void PublishMessageToRabbitMQAcks<T>(T message, string queueName);
}
