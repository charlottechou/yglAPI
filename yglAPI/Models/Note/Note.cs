using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yglAPI.Models.Note
{
    public class Note
    {
        public int id { get; set; }
        public int time { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }
    }
}
