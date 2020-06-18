using Microsoft.EntityFrameworkCore;
using System;
using CommonModels;
using PremiereReact.Models;

namespace PremiereReact
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Like> Likes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Film>().HasData(
                new Film { Id = 1, Name = "Иван Васильевич меняет профессию" },
                new Film { Id = 2, Name = "Приключения Электроника" },
                new Film { Id = 3, Name = "Кавказская пленница" }
            );
        }
    }
}
