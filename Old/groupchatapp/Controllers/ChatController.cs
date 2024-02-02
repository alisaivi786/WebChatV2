using GroupChatApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GroupChatApp.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public ChatController(ChatDbContext dbContext, UserManager<User> userManager, IHttpContextAccessor contextAccessor)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            //IHubContext<ChatHub> hubContext = _contextAccessor.HttpContext.RequestServices.GetRequiredService<IHubContext<ChatHub>>();

        }

        public IActionResult Chat(int id)
        {
            var group = _dbContext.Groups.Include(g => g.Messages).FirstOrDefault(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }

            // Check if user is a member of the group
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            //if (!group.Users.Any(u => u.Id == user.Id))
            //{
            //    return Unauthorized();
            //}

            return View(group);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int groupId, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest("Message cannot be empty.");
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var newMessage = new Message
            {
                Content = message,
                SentTime = DateTime.UtcNow,
                Sender = user,
                Group = _dbContext.Groups.Find(groupId)
            };

            _dbContext.Messages.Add(newMessage);
            await _dbContext.SaveChangesAsync();

            await _dbContext.SaveChangesAsync();

            // Inject a reference to the IHubContext<ChatHub>
            //IHubContext<ChatHub> hubContext = _contextAccessor.GetRequiredService<IHubContext<ChatHub>>();

            // Broadcast the new message to clients in the appropriate group
           // await hubContext.Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", newMessage);

            return RedirectToAction("Chat", new { id = groupId });
        }
    }
}
