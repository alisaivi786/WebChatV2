using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace GroupChatApp
{
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _dbContext;
        private readonly ConcurrentDictionary<string, List<int>> _groupsByConnectionId = new ConcurrentDictionary<string, List<int>>();

        public ChatHub(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task JoinGroup(int groupId)
        {
            // Retrieve the current user's ID
            // (Assuming you have a way to access this information in your hub context)
            int userId = GetCurrentUserId();

            // Add the user to the UserGroup table
            await _dbContext.UserGroup.AddAsync(new UserGroup { GroupId = groupId, UserId = userId });
            await _dbContext.SaveChangesAsync();

            // Add group to user's list of joined groups
            var connectionId = Context.ConnectionId;
            _groupsByConnectionId.AddOrUpdate(connectionId, new List<int> { groupId }, (_, existingGroups) =>
            {
                existingGroups.Add(groupId);
                return existingGroups;
            });

            // Notify other clients in the group about the new member
            await Clients.Group(groupId.ToString()).SendAsync("MemberJoined", Context.UserIdentifier);
        }


        public async Task LeaveGroup(int groupId)
        {
            // Remove user from group in database
            // ...

            // Remove group from user's list of joined groups
            //var connectionId = Context.ConnectionId;
            //_groupsByConnectionId.AddOrUpdate(connectionId, existingGroups =>
            //{
            //    existingGroups.Remove(groupId);
            //    return existingGroups.Count() > 0 ? existingGroups : null; // Invoke Count() // Return null only if no groups remain
            //}, (_, _) => null); // Remove connectionId entry if no groups remain

            // Notify other clients in the group about the member leaving
            await Clients.Group(groupId.ToString()).SendAsync("MemberLeft", Context.UserIdentifier);
        }

        public async Task SendMessage(int groupId, string message)
        {
            // Add message to database
            // ...

            // Broadcast message to all clients in the group
            await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", message);
        }

        // Other methods for managing groups/users as needed
        // ...

        public override async Task OnConnectedAsync()
        {
            // Add connection to tracking
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Remove connection from tracking and notify affected groups
            await base.OnDisconnectedAsync(exception);
            var connectionId = Context.ConnectionId;
            var groups = _groupsByConnectionId.GetOrAdd(connectionId, _ => new List<int>());
            foreach (var groupId in groups)
            {
                await Clients.Group(groupId.ToString()).SendAsync("MemberLeft", Context.UserIdentifier);
            }
            _groupsByConnectionId.TryRemove(connectionId, out _);
        }
    }
}
