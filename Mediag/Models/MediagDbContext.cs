﻿using Microsoft.EntityFrameworkCore;

namespace Mediag.Models
{
    class MediagDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string databaseName = "MediagDB";
            optionsBuilder.UseSqlServer($"{connectionString};Database={databaseName};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().HasData(
            //    new Person { Id = 1, Name = "John Doe", Age = 30 },
            //    new Person { Id = 2, Name = "Jane Doe", Age = 25 }
            //);
        }
    }
}