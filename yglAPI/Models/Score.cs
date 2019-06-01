using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Score
    {
        public int Id { get; set; }
        public int Sgrade { get; set; }
        public int Fgrade { get; set; }
        public int Mgrade { get; set; }
        public double Grade { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int Up { get; set; }
        public IEnumerable<string> imgList { get; set; }
    }
}
