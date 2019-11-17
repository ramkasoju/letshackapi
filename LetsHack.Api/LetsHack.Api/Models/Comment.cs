using System;

namespace LetsHack.Api.Models
{
    public class Comment
    {
        public string Text { get; set; }
        public User User { get; set; }
        public int HackId { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}