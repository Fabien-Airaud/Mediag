using Mediag.Models;
using Microsoft.EntityFrameworkCore;

namespace Mediag
{
    class MediagDbContext : DbContext
    {
        public DbSet<Models.Hospital> Hospitals { get; set; }
        public DbSet<Models.Doctor> Doctors { get; set; }
        public DbSet<Models.Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string databaseName = "MediagDB";
            optionsBuilder.UseSqlServer($"{connectionString};Database={databaseName};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().HasData(
                new Hospital { Id = 1, Name = "Hôpital général de Montréal", City = "Montréal" },
                new Hospital { Id = 2, Name = "Hôpital Charles-Le Moyne", City = "Greenfield Park" },
                new Hospital { Id = 3, Name = "Hôtel-Dieu d'Arthabaska", City = "Victoriaville" }
            );
        }
    }
}
