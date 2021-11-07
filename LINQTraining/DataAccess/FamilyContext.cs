using System;
using Microsoft.EntityFrameworkCore;
using Models;

namespace LINQTraining.DataAccess
{
    public class FamilyContext : DbContext
    {
        // Defining various tables
        public DbSet<Family> Families { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            throw new Exception("You need to set the absolute path of Family.db in the FamilyContext class, then delete this throw statement");
            optionsBuilder.UseSqlite(@"Data Source = C:\TRMO\RiderProjects\LINQTraining\LINQTraining\Family.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>()
                .HasKey(fam => new {fam.StreetName, fam.HouseNumber});
        }
    }
}