

namespace WebChat.RabbitMQ;

public interface IRabbitMQConsumer
{
    public Task StartConsuming();
}