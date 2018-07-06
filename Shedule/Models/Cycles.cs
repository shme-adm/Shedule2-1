﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shedule.Models
{
    public class Cycles
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public ICollection<Cycles_item> Cycles_item { get; set; }
        public Cycles()
        {
            Cycles_item = new List<Cycles_item>();
        }
    }
}