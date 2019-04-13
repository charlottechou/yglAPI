using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yglAPI.Models.News
{
    public class News
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int time { get; set; }
    }
}
