using System;
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
    }
}