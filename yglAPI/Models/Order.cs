using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int Gotime { get; set; }
        public int Productid { get; set; }
        public int Adult { get; set; }
        public int? Kid { get; set; }
        public int Amount { get; set; }
        public string State { get; set; }
    }
}
