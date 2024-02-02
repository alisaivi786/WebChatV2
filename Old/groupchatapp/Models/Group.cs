using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GroupChatApp.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}