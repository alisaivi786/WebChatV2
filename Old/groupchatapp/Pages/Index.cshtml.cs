using GroupChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GroupChatApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ChatDbContext _context;
    public IList<Group> Groups { get; set; }
    public IList<Message> Messages { get; set; } = default!;

    public IndexModel(ILogger<IndexModel> logger, ChatDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        int userId = 1;
        if (Request.Query.ContainsKey("userId") && !string.IsNullOrEmpty(Request.Query["userId"]))
        {
            // Ensure the value is a valid integer before parsing
            if (int.TryParse(Request.Query["userId"], out userId))
            {
                // Use the userId as needed
            }
            else
            {
                // Handle invalid userId format
                Console.WriteLine("Invalid userId format provided");
            }
        }
        Groups = _context.Groups.Where(g => g.Users.Any(u => u.Id == userId)).ToList();
        //Groups = _context.Groups.ToList();
    }

    public async Task<IActionResult> OnGetChat(int groupId)
    {
        int i = 0;
        // Retrieve chat messages for the given group ID
        // ...
        Groups = _context.Groups.ToList();

        return Page(); // Assuming you want to stay on the same page
    }

    public async Task<IActionResult> OnGetMessages(int groupId)
    {
        Messages = await _context.Messages.Where(m => m.Group.Id == groupId).ToListAsync();

        var responseData = new { groupId, messages = Messages };

        // Serialize the messages as JSON
        var json = JsonConvert.SerializeObject(responseData);

        return Content(json, "application/json");
    }
}
