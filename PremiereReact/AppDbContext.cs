using Microsoft.EntityFrameworkCore;
using System;
using CommonModels;
using PremiereReact.Models;

namespace PremiereServer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Like> Likes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Host=rogue.db.elephantsql.com;Database=qhlpwazs;Username=qhlpwazs;Password=F6ORA3IRNsf3LDmkDc-Zopmrd39PjxOq";
            optionsBuilder.UseNpgsql(connectionString, options => options.SetPostgresVersion(new Version(9, 6)));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Film>().HasData(
                new Film { Id = 1, Name = "Иван Васильевич меняет профессию" },
                new Film { Id = 2, Name = "Приключения Электроника" },
                new Film { Id = 3, Name = "Кавказская пленница" }
            );
            //builder.Entity<Session>().HasData(
            //    new Session { Id = 1, FilmId = 1, StartTime = new DateTime(2020, 6, 16, 22, 35, 0) },
            //    new Session { Id = 2, FilmId = 1, StartTime = new DateTime(2020, 6, 16, 19, 20, 0) },
            //    new Session { Id = 3, FilmId = 1, StartTime = new DateTime(2020, 6, 16, 17, 0, 0) },
            //    new Session { Id = 4, FilmId = 2, StartTime = new DateTime(2020, 6, 17, 19, 20, 0) },
            //    new Session { Id = 5, FilmId = 2, StartTime = new DateTime(2020, 6, 18, 19, 20, 0) }
            //    );
        }
    }
}
