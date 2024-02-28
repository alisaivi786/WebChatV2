

namespace WebChat.RabbitMQ;

/// <summary>
/// IRabbitMQConsumer Interface
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 01-02-2024
/// </summary>
public interface IRabbitMQConsumer
{
    public Task StartConsuming(string queueNamePattern);
    public Task StartConsumingDisconnectedUsers(string queueName);
}