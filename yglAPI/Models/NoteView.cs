﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yglAPI.Models
{
    public class NoteView:Note
    {
        public string nickname { get; set; }
        public string username { get; set; }
        public string head { get; set; }
    }
}