
namespace WebChat.RabbitMQ;

public interface IRabbitMQProducer
{
    public void PublishMessageToRabbitMQ<T>(T message);
}
