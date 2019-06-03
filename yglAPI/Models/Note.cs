using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public long Time { get; set; }
        public string Author { get; set; }
        public int? Up { get; set; }
        public string Member { get; set; }
        public int Days { get; set; }
        public long Gotime { get; set; }
        public int Averagefare { get; set; }
        public IEnumerable<string> imgList { get; set; }
    }
}
