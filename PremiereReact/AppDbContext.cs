using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiereServer.Models;

namespace PremiereServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Host=rogue.db.elephantsql.com;Database=qhlpwazs;Username=qhlpwazs;Password=F6ORA3IRNsf3LDmkDc-Zopmrd39PjxOq";
            optionsBuilder.UseNpgsql(connectionString, options => options.SetPostgresVersion(new Version(9, 6)));
        }
    }
}
