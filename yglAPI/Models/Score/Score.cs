using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yglAPI.Models.Score
{
    public class Score
    {
        public int id { get; set; }
        public int sgrade { get; set; }
        public int fgrade { get; set; }
        public int mgrade { get; set; }
        public int help { get; set; }
        public float grade { get; set; }
        public string content { get; set; }
        public string author { get; set; }
    }
}
