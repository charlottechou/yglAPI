using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Img
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
        public int toId { get; set; }
    }
}
