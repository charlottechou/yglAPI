using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Location { get; set; }
        public string Tag { get; set; }
        public string Img { get; set; }
        public int? Up { get; set; }

        public IEnumerable<string> imgList { get; set; }
    }
}
