namespace GroupChatApp.Models
{
    public class GroupChatModel
    {
        public Group Group { get; set; }

        public List<Message> Messages { get; set; } // Optional: For displaying message history
    }

}
