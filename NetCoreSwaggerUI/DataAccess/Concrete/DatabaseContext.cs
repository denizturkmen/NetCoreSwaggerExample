using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreSwaggerUI.Entities;

namespace NetCoreSwaggerUI.DataAccess.Concrete
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext()
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DENIZ-PC;Database=SwaggerDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person()
            {
                Id = 1,
                Adi = "Deniz",
                Soyadi = "Tttttttt"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
