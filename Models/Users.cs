using System;
using System.Collections.Generic;

namespace Ecourse.Models
{
    public partial class Users
    {
        public Users()
        {
            Answers = new HashSet<Answers>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

        public ICollection<Answers> Answers { get; set; }
    }
}
