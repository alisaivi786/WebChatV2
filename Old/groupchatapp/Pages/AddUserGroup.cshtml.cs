using GroupChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GroupChatApp.Pages
{
    public class AddUserGroupModel : PageModel
    {
        private readonly ChatDbContext _context;
        public int SelectedGroupId { get; set; }
        public int SelectedUserId { get; set; }
        public int GroupId { get; set; }

        public int UserId { get; set; }

        public List<Group> AvailableGroups { get; set; }
        public List<User> AvailableUsers { get; set; }

        public AddUserGroupModel(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            AvailableGroups = await _context.Groups.ToListAsync();
            ViewData["Groups"] = new SelectList(AvailableGroups, "Id", "Name");

            AvailableUsers = await _context.Users.ToListAsync();
            ViewData["Users"] = new SelectList(AvailableUsers, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            // Access the selected group ID
            int selectedGroupId = Convert.ToInt32(Request.Form["SelectedGroupId"]);
            int selectedUserId = Convert.ToInt32(Request.Form["SelectedUserId"]);

            var group = await _context.Groups.FirstOrDefaultAsync(m => m.Id == selectedGroupId);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == selectedUserId);

            if (group != null && user != null)
            {
                if(group.Users == null)
                {
                    group.Users = new List<User>();
                }

                group.Users.Add(user);
                _context.SaveChanges();
            }

            return Page();
        }
    }
}
