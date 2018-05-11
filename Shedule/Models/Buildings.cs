using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Buildings
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Адрес")]
        public string Comment { get; set; }

        [Display(Name = "Город")]
        public int? CitiesId { get; set; }
        public Cities Cities { get; set; }

        [Display(Name = "Подразделение")]
        public int? UnitsId { get; set; }
        public Units Units { get; set; }

        public ICollection<Cabinets> Cabinets { get; set; }
        public Buildings()
        {
            Cabinets = new List<Cabinets>();
        }

    }
}