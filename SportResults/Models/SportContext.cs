using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportResults.Models;
using System.Globalization;

namespace SportResults.Models
{
    public class SportContext : DbContext
    {
        //public SportContext()
        //    : base()
        //{
        //    //Database.EnsureCreated();
        //}

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
            modelBuilder.Entity<status>().HasData(
                new status() { id = 1, createdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), editdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), name = "Активно" },
                new status() { id = 2, createdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), editdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), name = "Аннулировано" });

            modelBuilder.Entity<disciplinetype>().HasData(
                new disciplinetype() { id = 1, createdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), editdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), statusid = 1, name = "Бег на 100м" },
                new disciplinetype() { id = 2, createdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), editdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), statusid = 1, name = "Бег на 60м" },
                new disciplinetype() { id = 3, createdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), editdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), statusid = 1, name = "Прыжок в длину" },
                new disciplinetype() { id = 4, createdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), editdate = DateTime.ParseExact("20211201", "yyyyMMdd", CultureInfo.InvariantCulture), statusid = 1, name = "Тройной прыжок в длину" });

        }

        public DbSet<SportResults.Models.competition> competitions { get; set; }

        public DbSet<SportResults.Models.discipline> discipline { get; set; }

        public DbSet<SportResults.Models.disciplinetype> disciplinetype { get; set; }

        public DbSet<SportResults.Models.status> status { get; set; }

    }
}
