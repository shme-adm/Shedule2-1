using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; } 
        public string Comment { get; set; }
    }
}