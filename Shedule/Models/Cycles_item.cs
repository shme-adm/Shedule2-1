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

        [Display(Name = "Тема")]
        public string Name { get; set; }

        [Display(Name = "Часы")]
        public int? Hours { get; set; }

        public int? SubjectsGroupsId { get; set; }
        
        [Display(Name = "Цикл")]
        public int? CyclesId { get; set; }
        public Cycles Cycles { get; set; }

        //public int? SubjectId { get; set; }
        //public Subjects Subjects { get; set; }
    }
}