using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Subjects_groups
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Subjects> Subjects { get; set; }
        public Subjects_groups()
        {
            Subjects = new List<Subjects>();
        }
    }
}