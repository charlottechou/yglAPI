using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public int? Up { get; set; }
        public string Location { get; set; }
    }
}
