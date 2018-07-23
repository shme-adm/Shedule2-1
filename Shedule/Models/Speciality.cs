using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shedule.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        //public int? Subjects_groupsId { get; set; }
        //public Subjects_groups Subjects_groups { get; set; }

        //public ICollection<Speciality_item> Speciality_item { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
        public Speciality()
        {
            //Speciality_item = new List<Speciality_item>();
            Subjects = new List<Subjects>();
        }
        //public Cycles(string name)
        //{
        //}
    }
    
}