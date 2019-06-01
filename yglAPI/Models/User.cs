using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Sex { get; set; }
        public string Nickname { get; set; }
        public long? Age { get; set; }
        public string Tag { get; set; }
        public string Head { get; set; }
        public string Role { get; set; }
        public IEnumerable<string> TagList { get; set; }
    }
}
