
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WebChat.Application.Contracts.UnitOfWork;
using WebChat.Common.Dto.RequestDtos.Message;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.RabbitMQ;
using WebChat.Redis;
using WebChat.Redis.RedisHelper;

namespace WebChat.Hubs;

/// <summary>
/// ChatHub
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 01-02-2024
/// </summary>
public class ChatHub(IRabbitMQProducer RabbitMQProducer, IRabbitMQConsumer RabbitMQConsumer,
    IRedisService2<MessageDetailDto> RedisService2,
    IUserDetailsService UserDetailsService,
    IUnitOfWork UnitOfWork) : Hub
{
    #region Declaring private fields
    private readonly IRabbitMQProducer RabbitMQProducer = RabbitMQProducer;
    private readonly IRabbitMQConsumer RabbitMQConsumer = RabbitMQConsumer;

    private static Dictionary<string, string> connectedUsers = [];

    private AddMessageReqDto addMessageReqDto = new();
    #endregion

    #region OnConnectedAsync
    /// <summary>
    /// OnConnectedAsync
    /// </summary>
    /// <returns>Task</returns>
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("--> Connection Opened: " + Context.ConnectionId);
        Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID", Context.ConnectionId);
        return base.OnConnectedAsync();
    }
    #endregion

    #region JoinGroup
    /// <summary>
    /// JoinGroup
    /// </summary>
    /// <param name="SubGroupId"></param>
    /// <param name="UserId"></param>
    /// <returns>Task</returns>
    public async Task JoinGroup(string SubGroupId, string UserId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, SubGroupId);

        connectedUsers[Context.ConnectionId] = UserId;

        Console.WriteLine($"--> Connection {Context.ConnectionId} joined group: {SubGroupId}");
    }
    #endregion

    #region LeaveGroup
    /// <summary>
    /// LeaveGroup
    /// </summary>
    /// <param name="SubGroupId"></param>
    /// <returns>Task</returns>
    public async Task LeaveGroup(string SubGroupId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, SubGroupId);
        Console.WriteLine($"--> Connection {Context.ConnectionId} left group: {SubGroupId}");
    }
    #endregion

    #region SendMessageAsync
    /// <summary>
    /// SendMessageAsync
    /// </summary>
    /// <param name="message"></param>
    /// <returns>Task</returns>
    public async Task SendMessageAsync(string message)
    {
        string MessageReqjson;
        MessageDetailDto mappedrequest;

        var routeOb = JsonConvert.DeserializeObject<dynamic>(message);

        MessageDetailDto MessageReq = new()
        {
            SubGroupId = routeOb?.SubGroupId,
            UserId = routeOb?.UserId,
            Message = routeOb?.Message.ToString(),
            Time = routeOb?.Time,
            UUID = routeOb?.UUID
        };

        var SubGroupId = $"[{MessageReq.SubGroupId?.ToString()}]";

        #region [0] Map User Details and prepare the json
        // mappedrequest = await RedisService.MapUserDetailsAsync(MessageReq);

        // var MessageReqjson = JsonConvert.SerializeObject(mappedrequest);

        // MessageReqjson = JsonConvert.SerializeObject(mappedrequest);
        #endregion

        #region [1] Push to Redis
        await Console.Out.WriteLineAsync("--> ChatHub: calling PushMessageToRedisAsync");
        var redisKey = string.Format(CommonCacheKey.chatroom, SubGroupId);
        // RedisService.PushMessageToRedisAsync(message: MessageReqjson, roomId: SubGroupId);

        try
        {
            // mappedrequest = await RedisService.MapUserDetailsAsync(MessageReq);
            mappedrequest = await UserDetailsService.MapUserDetailsAsync(CommonCacheKey.cacheKey_users_usersdetails, MessageReq);
            MessageReqjson = JsonConvert.SerializeObject(mappedrequest);

            RedisService2.PushMessageToRedisAsync(key: redisKey, message: mappedrequest);
            RabbitMQProducer.TimedPublishMessageToRabbitMQAcks(mappedrequest, sourceQueue: $"source_queue_{SubGroupId}", destinationQueue: $"destination_queue_{SubGroupId}", groupId: SubGroupId);
        }
        catch (Exception)
        {
            #region Consume the source and destination queue
            // await RabbitMQProducer.StartConsuming(queueNamePattern: "source_queue_*");
            // await RabbitMQConsumer.StartConsuming(queueNamePattern: "destination_queue_*");
            #endregion

            MessageReqjson = JsonConvert.SerializeObject(MessageReq);

            #region Push directly to the database
            addMessageReqDto = new AddMessageReqDto()
            {
                Message = routeOb?.Message,
                UserId = routeOb?.UserId,
                SubGroupId = routeOb?.SubGroupId,
                SetTime = routeOb?.Time,
                UUID = routeOb?.Uuid
            };
            #endregion

            await UnitOfWork.MessageRepository.AddMessageAsync(addMessageReqDto);
        }

        #endregion

        #region [2] Publish to Queue
        // RabbitMQProducer.TimedPublishMessageToRabbitMQ(mappedrequest, sourceQueue: $"source_queue_{SubGroupId}", destinationQueue: $"destination_queue_{SubGroupId}",groupId: SubGroupId);
        // RabbitMQProducer.TimedPublishMessageToRabbitMQAcks(mappedrequest, sourceQueue: $"source_queue_{SubGroupId}", destinationQueue: $"destination_queue_{SubGroupId}", groupId: SubGroupId);
        #endregion

        #region [3] Consume Queue & Sync with the database
        // await RabbitMQConsumer.StartConsuming(queueNamePattern: "destination_queue_*");
        #endregion

        await Clients.Group(MessageReq.SubGroupId.ToString()).SendAsync("ReceiveMessage", MessageReq.UserId, MessageReqjson);
    }
    #endregion
}