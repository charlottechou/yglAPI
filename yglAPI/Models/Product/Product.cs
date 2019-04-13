using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yglAPI.Models.Product
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int kidprice { get; set; }
        public int adultprice { get; set; }
        public string content { get; set; }
        public string tag { get; set; }
    }
}
