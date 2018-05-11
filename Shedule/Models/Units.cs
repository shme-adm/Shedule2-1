using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Units
    {
        public int Id { get; set; }
        [Display (Name="Наименование")]
        public string Name { get; set; }

        [Display(Name = "Город")]
        public int? CitiesId { get; set; }
        public Cities Cities { get; set; }

        public ICollection<Buildings> Buildings { get; set; }
        public Units()
        {
            Buildings = new List<Buildings>();
        }
    }
}