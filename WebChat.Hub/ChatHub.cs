using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WebChat.Domain.Entities;
using WebChat.RabbitMQ;
using WebChat.Redis;

namespace WebChat.Hubs;

public class ChatHub(IRabbitMQProducer RabbitMQProducer, IRabbitMQConsumer RabbitMQConsumer, IRedisService RedisService) : Hub
{
    #region Declaring private fields
    private readonly IRabbitMQProducer RabbitMQProducer = RabbitMQProducer;
    private readonly IRabbitMQConsumer RabbitMQConsumer = RabbitMQConsumer;

    private readonly IRedisService RedisService = RedisService;
    #endregion

    #region OnConnectedAsync
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("--> Connection Opened: " + Context.ConnectionId);
        Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID", Context.ConnectionId);
        return base.OnConnectedAsync();
    }
    #endregion

    #region SendMessageAsync
    public async Task SendMessageAsync(string message)
    {
        var ConnectionId = Context.ConnectionId;

        var routeOb = JsonConvert.DeserializeObject<dynamic>(message);

        MessageEntity messageEntity = new MessageEntity()
        {
            // RowId = Guid.NewGuid(),
            GroupId = Convert.ToInt64(Context.ConnectionId),
            UserId = 15672,
            Content = routeOb?.Message.ToString(),// message,
            //DateCreated = DateTime.Now.ToUniversalTime(),
            SentTime = DateTime.Now.ToUniversalTime(),
        };

        var messageEntityjson = JsonConvert.SerializeObject(messageEntity);

        
          Console.WriteLine("To: " + routeOb?.To.ToString());
        Console.WriteLine("Message Recieved on: " + Context.ConnectionId);

        #region [1] Publish to Queue
        RabbitMQProducer.PublishMessageToRabbitMQ(messageEntityjson);
        #endregion

        #region [2] Push to Redis
        RedisService.PushMessageToRedisAsync(message: messageEntityjson, roomId: messageEntity.GroupId.ToString());
        #endregion

        #region [3] Consume Queue & Sync with the database
        await RabbitMQConsumer.StartConsuming();
        #endregion

        if (routeOb.To.ToString() == string.Empty)
        {
            Console.WriteLine("Broadcast");
            await Clients.All.SendAsync("ReceiveMessage", messageEntityjson);
        }
        else
        {
            string toClient = routeOb.To;
            Console.WriteLine("Targeted on: " + toClient);

            await Clients.Client(toClient).SendAsync("ReceiveMessage", messageEntityjson);
        }
    }
    #endregion
}