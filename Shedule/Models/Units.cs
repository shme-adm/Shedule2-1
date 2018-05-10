using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shedule.Models
{
    public class Units
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CitiesId { get; set; }
        public Cities Cities { get; set; }
    }
}