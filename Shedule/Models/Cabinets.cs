using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Cabinets
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "Лекция")]
        public bool Lecture { get; set; }

        [Display(Name = "Практика")]
        public bool Practice { get; set; }

        [Display(Name = "Здание")]
        public int? BuildingsId { get; set; }
        public Buildings Buildings { get; set; }
        
    }
}