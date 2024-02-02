using System.ComponentModel.DataAnnotations;

namespace GroupChatApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime SentTime { get; set; }
        public User? Sender { get; set; }
        public Group? Group { get; set; }
    }
}