using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yglAPI.Models.Attraction
{
    public class Attraction
    {
        public int id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public string location { get; set; }
        public string tag { get; set; }
    }
}
