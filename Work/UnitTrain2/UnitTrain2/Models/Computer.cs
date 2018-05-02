using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnitTrain2.Models
{
    // модель
    public class Computer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // контекст
    public class CompContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
    }
}