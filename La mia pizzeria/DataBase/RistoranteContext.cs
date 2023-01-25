using System;
using La_mia_pizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace La_mia_pizzeria.DataBase
{
    public class RistoranteContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Pizza1DB;User Id=SA;Password=devKiiiiry_1;TrustServerCertificate=True");
        }
       
        
    }
}
