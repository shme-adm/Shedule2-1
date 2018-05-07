using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity

namespace Shedule.Models
{
    public class ShedulerContext
    {
        public DbSet<Cities> Cities { get; set; }
    }
}