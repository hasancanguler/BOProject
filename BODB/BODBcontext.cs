using Microsoft.EntityFrameworkCore;
using System;

namespace BODB
{
    public class BODBcontext : DbContext
    {
        public BODBcontext() 
        {

        }

        public DbSet<Complaints> Complaints { get; set; }
        public DbSet<Company> Company { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaints>().ToTable("Complaints");
            modelBuilder.Entity<Company>().ToTable("Company");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=mssql08.turhost.com;Database=DBBO;User Id=bouser;Password=Kalem12!;");
        }
    }
}
