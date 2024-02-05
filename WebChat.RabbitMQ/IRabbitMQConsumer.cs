

namespace WebChat.RabbitMQ;

public interface IRabbitMQConsumer
{
    public Task StartConsuming();
    public void StartConsuming(Action<string> onMessageReceived);
}