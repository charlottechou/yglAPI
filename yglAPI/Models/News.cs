﻿using System;
using System.Collections.Generic;

namespace yglAPI.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long Time { get; set; }
        public string Author { get; set; }
        public IEnumerable<string> imgList { get; set; }
    }
}
