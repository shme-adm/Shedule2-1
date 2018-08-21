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
        public string type { get; set; }
        public string _group { get; set; }
        public string subject { get; set; }
        public string cabinet { get; set; }
        public string teacher { get; set; }
        public string unit { get; set; }
        //public virtual ICollection<Groups> Groups { get; set; }
        //public Events()
        //{
        //    Groups = new List<Groups>();
        //}
    }
}