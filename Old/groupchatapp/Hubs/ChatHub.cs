using GroupChatApp.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using StackExchange.Redis;


namespace GroupChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToGroup(string groupId, string user, string message)
        {
            Console.WriteLine("SendMessageToGroup: user" + user + " ; group " + groupId);
            //ConsumeMessageFromRabbitMQ();
            PublishMessageToRabbitMQ(message);

            await Clients.Group(groupId).SendAsync("ReceiveMessage", user, message);

            using (var db = new ChatDbContext())
            {
                User userObj = db.Users.FirstOrDefault(u => u.Id == Convert.ToInt32(user));
                Group groupObj = db.Groups.FirstOrDefault(g => g.Id == Convert.ToInt32(groupId));

                if (userObj == null || groupObj == null)
                {
                    Console.WriteLine("Invalid data: user" + user + " ; group " + groupId); return;
                }

                Message messageObj = new Message();
                messageObj.Content = message;
                messageObj.Sender = userObj;
                messageObj.Group = groupObj;

                db.Messages.Add(messageObj);
                db.SaveChanges();
                Console.WriteLine("Message " + message + " saved");
            }
        }

        public void PublishMessageToRabbitMQ(string message)
        {
            using var connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            }.CreateConnection();

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "my_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
               // string message = "Hello, RabbitMQ!";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "", routingKey: "my_queue", basicProperties: null, body: body);
                Console.WriteLine($"Sent: {message}");
            }
        }

        public void ConsumeMessageFromRabbitMQ()
        {
            using var connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            }.CreateConnection();

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "my_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($"Received: {message}");
                };
                channel.BasicConsume(queue: "my_queue", autoAck: true, consumer: consumer);
                Console.WriteLine("Waiting for messages. Press [Enter] to exit.");
                Console.ReadLine();
            }
        }

        public async Task AddToGroup(int groupId, int userId)
        {
            using (var db = new ChatDbContext())
            {
                var groupMapping = db.Users.FirstOrDefault(u => u.Groupss.FirstOrDefault(g => g.Id == groupId) != null);

                if (groupMapping != null)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, groupMapping.Id.ToString());
                }

                //var groupMapping = db.Users.FirstOrDefault(u => u.Groupss.FirstOrDefault(g => g.Id == groupId) != null) //db.Groups.FirstOrDefault(g => g.Users.FirstOrDefault(u => u.Id == userId));
            }
            //await Groups.AddToGroupAsync(Context.ConnectionId, groupId);

            //await Clients.Group(groupId).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupId}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }
        public Task SendPrivateMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", message);
        }

        //public override Task OnConnectedAsync()
        //{
        //    using (var db = new ChatDbContext())
        //    {
        //        // Retrieve user.
        //        var user = db.Users.Include(u => u.Groupss)
        //            .SingleOrDefault(u => u.Name == Context.User.Identity.Name);

        //        // If user does not exist in database, must add.
        //        if (user == null)
        //        {
        //            user = new User()
        //            {
        //                Name = Context.User.Identity.Name
        //            };
        //            db.Users.Add(user);
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            // Add to each assigned group.
        //            foreach (var item in user.Groupss)
        //            {
        //                Groups.AddToGroupAsync(Context.ConnectionId, item.Name);
        //            }
        //        }
        //    }
        //    return base.OnConnectedAsync();
        //}

        //public void AddToRoom(string roomName)
        //{
        //    using (var db = new ChatDbContext())
        //    {
        //        // Retrieve room.
        //        var room = db.Groups.Find(roomName);

        //        if (room != null)
        //        {
        //            var user = new User() { Name = Context.User.Identity.Name };
        //            db.Users.Attach(user);

        //            room.Users.Add(user);
        //            db.SaveChanges();
        //            Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        //        }
        //    }
        //}

        //public void RemoveFromRoom(string roomName)
        //{
        //    using (var db = new ChatDbContext())
        //    {
        //        // Retrieve room.
        //        var room = db.Groups.Find(roomName);
        //        if (room != null)
        //        {
        //            var user = new User() { Name = Context.User.Identity.Name };
        //            db.Users.Attach(user);

        //            room.Users.Remove(user);
        //            db.SaveChanges();

        //            Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        //        }
        //    }
        //}

        //private readonly IGroupManager _groupManager;
        //public ChatHub(IGroupManager groupManager)
        //{
        //    _groupManager = groupManager;
        //}
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
}
