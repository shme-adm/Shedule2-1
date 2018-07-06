using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shedule.Models
{
    public class Cycles_item
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        //[Display(Name = "")]
        [Display(Name = "Предмет")]
        public int? CyclesId { get; set; }
        public Cycles Cycles { get; set; }
    }
}