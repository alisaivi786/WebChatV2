using System.ComponentModel.DataAnnotations;

namespace GroupChatApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Group>? Groupss { get; set; }
    }
}