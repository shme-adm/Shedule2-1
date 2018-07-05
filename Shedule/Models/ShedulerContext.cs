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
        public DbSet<Buildings> Buildings { get; set; }
        public DbSet<Cabinets> Cabinets { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Subjects_groups> Subjects_groups { get; set; }
        public DbSet<TypeOfClasses> TypeOfClasses { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Cycles> Cycles { get; set; }
    }
}