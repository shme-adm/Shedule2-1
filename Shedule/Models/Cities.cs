using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Cities
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public ICollection<Units> Units { get; set; }
        public ICollection<Buildings> Buildings { get; set; }
        public Cities()
        {
            Units = new List<Units>();
            Buildings = new List<Buildings>();
        }
                
    }
}