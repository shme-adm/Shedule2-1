﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[Display(Name = "")]
        public int? Subjects_groupsId { get; set; }
        public Subjects_groups Subjects_groups { get; set; }
    }
}