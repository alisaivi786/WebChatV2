
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WebChat.Common.Dto.ResponseDtos.Message;
using WebChat.RabbitMQ;
using WebChat.Redis;

namespace WebChat.Hubs;

/// <summary>
/// ChatHub
/// Developer: AYMAN MUSTAFA ADLAN
/// Date: 01-02-2024
/// </summary>
public class ChatHub(IRabbitMQProducer RabbitMQProducer, IRabbitMQConsumer RabbitMQConsumer, IRedisService RedisService) : Hub
{
    #region Declaring private fields
    private readonly IRabbitMQProducer RabbitMQProducer = RabbitMQProducer;
    private readonly IRabbitMQConsumer RabbitMQConsumer = RabbitMQConsumer;

    private readonly IRedisService RedisService = RedisService;
    private static Dictionary<string, string> connectedUsers = new Dictionary<string, string>();
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
        var routeOb = JsonConvert.DeserializeObject<dynamic>(message);

        MessageDetailDto MessageReq = new()
        {
            SubGroupId = routeOb?.SubGroupId, //1,
            SubGroupName = routeOb?.SubGroupName.ToString(), //"TB-Admin",
            UserId = routeOb?.UserId,
            UserName = routeOb?.UserName,
            UserPhoto = routeOb?.UserPhoto,
            NickName = routeOb?.NickName,
            Message = routeOb?.Message.ToString(),
            Time = routeOb?.Time,
            UUID = routeOb?.UUID
        };

        var SubGroupId = $"[{MessageReq.SubGroupId?.ToString()}]";

        #region [0] Map User Details and prepare the json
        var mappedrequest = await RedisService.MapUserDetailsAsync(MessageReq);
        // var MessageReqjson = JsonConvert.SerializeObject(mappedrequest);

        var MessageReqjson = JsonConvert.SerializeObject(mappedrequest);
        #endregion

        #region [1] Publish to Queue
        // RabbitMQProducer.TimedPublishMessageToRabbitMQ(mappedrequest, sourceQueue: $"source_queue_{SubGroupId}", destinationQueue: $"destination_queue_{SubGroupId}",groupId: SubGroupId);
        RabbitMQProducer.TimedPublishMessageToRabbitMQAcks(mappedrequest, sourceQueue: $"source_queue_{SubGroupId}", destinationQueue: $"destination_queue_{SubGroupId}", groupId: SubGroupId);
        #endregion

        #region [2] Push to Redis
        await Console.Out.WriteLineAsync("-->ChatHub: calling PushMessageToRedisAsync");
        RedisService.PushMessageToRedisAsync(message: MessageReqjson, roomId: SubGroupId);
        #endregion

        #region [3] Consume Queue & Sync with the database
        // await RabbitMQConsumer.StartConsuming(queueNamePattern: "destination_queue_*");
        #endregion

        await Clients.Group(mappedrequest.SubGroupId.ToString()).SendAsync("ReceiveMessage", mappedrequest.UserId, MessageReqjson);
    }
    #endregion


    #region Disconnection Management

    #region OnDisconnectedAsync
    /// <summary>
    /// OnDisconnectedAsync
    /// </summary>
    /// <param name="exception"></param>
    /// <returns>Task</returns>
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        //  SetPageRefreshFlag();

        //   var isPageRefresh = Context.Items["IsPageRefresh"] as bool?;

        //if ((bool)!isPageRefresh)
        //{
        //    if (connectedUsers.TryGetValue(Context.ConnectionId, out var userId))
        //    {
        //        Console.WriteLine($"--> Connection {Context.ConnectionId} (UserId: {userId}) disconnected");

        //        var User = new DeleteGroupUserReqDto() { UserId = Convert.ToInt32(userId) };

        //        RabbitMQProducer.PublishMessageToRabbitMQ(User, "DisconnectedUsers_queue");
        //    }

        //    connectedUsers.Remove(Context.ConnectionId);
        //}
    }

    public void SetPageRefreshFlag()
    {
        Context.Items["IsPageRefresh"] = true;
    }
    #endregion

    #region SendHeartbeat
    public async Task SendHeartbeat()
    {
        // Optionally, update a timestamp or perform other actions
        // to indicate that the client is still connected
        // For example, you could store the last heartbeat timestamp in a dictionary

        // Store the last heartbeat timestamp for the client
        var connectionId = Context.ConnectionId;
        // Assuming a dictionary to store timestamps for each connection
        // You may want to use a concurrent dictionary for thread safety
        // Adjust this based on your specific requirements
        // Also, consider implementing cleanup logic to remove stale entries
        HeartbeatManager.SetLastHeartbeat(connectionId, DateTime.UtcNow);

        // You can perform other actions if needed
        // For example, broadcast a message to all clients
        // Clients.All.SendAsync("ReceiveMessage", $"{connectionId} sent a heartbeat");

        await Console.Out.WriteLineAsync("--> SendHeartbeat");
    }
    #endregion

    #region CheckIdleConnections
    public async Task CheckIdleConnections(CancellationToken cancellationToke)
    {
        await Console.Out.WriteLineAsync("--> ChatHub: CheckIdleConnections");

        // var timeout = TimeSpan.FromMinutes(1); // Adjust the timeout as needed
        var timeout = TimeSpan.FromSeconds(10); // Adjust the timeout as needed

        foreach (var connectionId in HeartbeatManager.GetConnectionIds())
        {
            var lastHeartbeat = HeartbeatManager.GetLastHeartbeat(connectionId);

            if (DateTime.UtcNow - lastHeartbeat > timeout)
            {
                // Disconnect the idle connection

                //  await Clients.Client(connectionId).SendAsync("Disconnect", "Idle connection timeout");
                //  await Context.Connection.StopAsync(); // Disconnect the connection
            }
        }
    }
    #endregion

    #endregion
}