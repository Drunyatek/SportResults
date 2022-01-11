using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportResults.Models;

namespace SportResults.Models
{
    public class SportContext : DbContext
    {
        public SportContext(DbContextOptions<SportContext> dbContextOptions)
            : base(dbContextOptions)
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status() { Id = 1, CreateDate = DateTime.Now, EditDate = DateTime.Now, Name = "Активно" },
                new Status() { Id = 2, CreateDate = DateTime.Now, EditDate = DateTime.Now, Name = "Аннулировано" });

            modelBuilder.Entity<DisciplineType>().HasData(
                new DisciplineType() { Id = 1, CreateDate = DateTime.Parse("30.12.2021"), EditDate = DateTime.Parse("30.12.2021"), StatusId = 1, Name = "Бег на 100м" },
                new DisciplineType() { Id = 2, CreateDate = DateTime.Parse("30.12.2021"), EditDate = DateTime.Parse("30.12.2021"), StatusId = 1, Name = "Бег на 60м" },
                new DisciplineType() { Id = 3, CreateDate = DateTime.Parse("30.12.2021"), EditDate = DateTime.Parse("30.12.2021"), StatusId = 1, Name = "Прыжок в длину" },
                new DisciplineType() { Id = 4, CreateDate = DateTime.Parse("30.12.2021"), EditDate = DateTime.Parse("30.12.2021"), StatusId = 1, Name = "Тройной прыжок в длину" });

        }

        public DbSet<SportResults.Models.Competition> Competitions { get; set; }

        public DbSet<SportResults.Models.Discipline> Discipline { get; set; }

        public DbSet<SportResults.Models.DisciplineType> DisciplineType { get; set; }

        public DbSet<SportResults.Models.Status> Status { get; set; }

    }
}
