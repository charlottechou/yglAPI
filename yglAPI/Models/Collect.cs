using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Collect
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
    }
}
