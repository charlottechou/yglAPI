using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kidprice { get; set; }
        public string Content { get; set; }
        public int Adultprice { get; set; }
        public string Tag { get; set; }
        public IEnumerable<string> imgList { get; set; }
    }
}
