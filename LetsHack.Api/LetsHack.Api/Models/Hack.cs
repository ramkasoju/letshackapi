using System.Collections.Generic;

namespace LetsHack.Api.Models
{
    public class Hack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public bool Approved { get; set; }
        public List<User> Participants { get; set; }
    }
}