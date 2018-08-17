﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Events
    {
        public int id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string text { get; set; }
    }
}