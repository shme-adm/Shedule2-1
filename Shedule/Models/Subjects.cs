using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        //[Display(Name = "")]
        [Display(Name = "Предмет")]
        public int? Subjects_groupsId { get; set; }
        public Subjects_groups Subjects_groups { get; set; }

       

        //public virtual ICollection<Cycles> Cycle { get; set; }
        //public Subjects()
        //{
        //    Cycle = new List<Cycles>();
        //}
        //public int Cycles_itemId { get; set; }
        //public Cycles_item Cycles_item { get; set; }
        //public ICollection<Cycles_item> Cycles_item { get; set; }
        //public Subjects()
        //{
        //    Cycles_item = new List<Cycles_item>();
        //}
    }
}