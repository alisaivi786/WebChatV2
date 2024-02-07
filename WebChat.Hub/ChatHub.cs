using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WebChat.Common.Dto.ResponseDtos.Message;
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

        //AddMessageReqDto MessageReq = new AddMessageReqDto()
        //{
        //    GroupId = 148,
        //    UserId = 15672,
        //    Message = routeOb?.Message.ToString(),
        //    SetTime = DateTime.Now,
        //};

        MessageDetailDto MessageReq = new MessageDetailDto()
        {
            GroupId = routeOb?.GroupId, //1,
            GroupName = routeOb?.GroupName.ToString(), //"TB-Admin",
            UserId = 3,
            UserName = "Aymen",
            Message = routeOb?.Message.ToString(),
            Time = routeOb?.TimeUTC
        };

        var MessageReqjson = JsonConvert.SerializeObject(MessageReq);

        
          Console.WriteLine("To: " + routeOb?.To.ToString());
        Console.WriteLine("Message Recieved on: " + Context.ConnectionId);

        #region [1] Publish to Queue
        RabbitMQProducer.PublishMessageToRabbitMQ(MessageReqjson);
        #endregion

        #region [2] Push to Redis
        RedisService.PushMessageToRedisAsync(message: MessageReqjson, roomId: MessageReq.GroupId.ToString());
        #endregion

        #region [3] Consume Queue & Sync with the database
        await RabbitMQConsumer.StartConsuming();
        #endregion

        if (routeOb.To.ToString() == string.Empty)
        {
            Console.WriteLine("Broadcast");
            await Clients.All.SendAsync("ReceiveMessage", MessageReqjson);
        }
        else
        {
            string toClient = routeOb.To;
            Console.WriteLine("Targeted on: " + toClient);

            await Clients.Client(toClient).SendAsync("ReceiveMessage", MessageReqjson);
        }
    }
    #endregion

}