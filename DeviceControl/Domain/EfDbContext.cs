using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Domain
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }
        public DbSet<Device> Devices { get; set; }
        public DbSet<AutomaticMode> Modes { get; set; }
        public DbSet<Indicator> Indicators { get; set;}
    }
}
