using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Bigtitle { get; set; }
        public string Smalltitle { get; set; }
        public int Time { get; set; }
        public int Member { get; set; }
        public string Connet { get; set; }
        public string Author { get; set; }
        public int? Up { get; set; }
        public IEnumerable<string> imgList { get; set; }
    }
}
