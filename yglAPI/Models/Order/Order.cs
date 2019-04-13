using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yglAPI.Models.Order
{
    public class Order
    {
        public int id { get; set; }
        public int gotime { get; set; }
        public int kid { get; set; }
        public int adult { get; set; }
        public int productid { get; set; }
        public int sum { get; set; }
        public string state { get; set; }
    }
}
