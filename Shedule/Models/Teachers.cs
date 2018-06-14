using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shedule.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        public string Middlename { get; set; }
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        [Display(Name = "Штатный")]
        public bool Staff { get; set; }
    }
}