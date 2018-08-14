using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shedule.Models
{
    public class Groups
    {
        public int Id { get; set; }
        
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Дата начала обучения")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Дата окончания обучения")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        [Display(Name = "Количество подгрупп")]
        public int? QuantitySubGroups { get; set; }

        [Display(Name = "Бюджет")]
        public bool Budget { get; set; }

        [Display(Name = "Цикл")]
        public int? CyclesId { get; set; }
        public Cycles Cycles { get; set; }

        [Display(Name = "Город")]
        public int? CityId { get; set; }
        public Cities City { get; set; }
    }
}