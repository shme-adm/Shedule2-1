using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shedule.Models
{
    public class Speciality_item
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Часы")]
        public int? Hours { get; set; }
        //[Display(Name = "")]
        [Display(Name = "Предмет")]
        public int? SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }
}