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
        public int? Age { get; set; }
        public int? Tag { get; set; }
        public string Head { get; set; }
        public string Role { get; set; }
    }
}
