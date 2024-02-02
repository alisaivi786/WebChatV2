using Microsoft.AspNetCore.SignalR;
using WebChat.RabbitMQ;

namespace WebChat.Hubs;

public class ChatHub : Hub
{
    private readonly IRabbitMQProducer RabbitMQProducer;
    public ChatHub(IRabbitMQProducer RabbitMQProducer)
    {
            this.RabbitMQProducer = RabbitMQProducer;
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public async Task SendMessageToGroup(string groupId, string user, string message)
    {
        Console.WriteLine("SendMessageToGroup: user" + user + " ; group " + groupId);

        await Clients.Group(groupId).SendAsync("ReceiveMessage", user, message);

        RabbitMQProducer.PublishMessageToRabbitMQ(message);

    }
}