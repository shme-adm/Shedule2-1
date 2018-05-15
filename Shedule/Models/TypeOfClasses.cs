using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class TypeOfClasses
    {
       public int Id { get; set; }
       public Guid Guid { get; set; }
       [Display(Name="Наименование")]
       public string Name { get; set; }       
    }
}