using Mediag.Models;
using Microsoft.EntityFrameworkCore;

namespace Mediag
{
    class MediagDbContext : DbContext
    {
        public DbSet<IllnessTypes> IllnessTypes { get; set; }
        public DbSet<ChestPainTypes> ChestPainTypes { get; set; }
        public DbSet<ThalassemiaTypes> ThalassemiaTypes { get; set; }
        public DbSet<MajorVesselsTypes> MajorVesselsTypes { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalFile> MedicalFiles { get; set; }
        public DbSet<BreastCancerData> BreastCancerDatas { get; set; }

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
            modelBuilder.Entity<IllnessTypes>().HasData(
                new IllnessTypes { Id = 1, Name = "Breast cancer" },
                new IllnessTypes { Id = 2, Name = "Heart disease" }
            );
            modelBuilder.Entity<ChestPainTypes>().HasData(
                new ChestPainTypes { Id = 1, Name = "Typical angina" },
                new ChestPainTypes { Id = 2, Name = "Atypical angina" },
                new ChestPainTypes { Id = 3, Name = "Non anginal pain" },
                new ChestPainTypes { Id = 4, Name = "Asymptomatic" }
            );
            modelBuilder.Entity<ThalassemiaTypes>().HasData(
                new ThalassemiaTypes { Id = 1, Name = "Strange" },
                new ThalassemiaTypes { Id = 2, Name = "Normal" },
                new ThalassemiaTypes { Id = 3, Name = "Fixed" },
                new ThalassemiaTypes { Id = 4, Name = "Reversable" }
            );
            modelBuilder.Entity<MajorVesselsTypes>().HasData(
                new MajorVesselsTypes { Id = 1, Name = "Zero" },
                new MajorVesselsTypes { Id = 2, Name = "One" },
                new MajorVesselsTypes { Id = 3, Name = "Two" },
                new MajorVesselsTypes { Id = 4, Name = "Three" },
                new MajorVesselsTypes { Id = 5, Name = "Four" }
            );
        }
    }
}
