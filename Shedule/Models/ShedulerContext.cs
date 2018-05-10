using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Shedule.Models
{
    public class ShedulerContext: DbContext
    {
        public ShedulerContext() : base("DefaultConnection"){ }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Units> Units { get; set; }
    }
}