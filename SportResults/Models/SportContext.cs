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

        public DbSet<SportResults.Models.Competition> Competitions { get; set; }

        public DbSet<SportResults.Models.Discipline> Discipline { get; set; }

        public DbSet<SportResults.Models.DisciplineType> DisciplineType { get; set; }

        public DbSet<SportResults.Models.Status> Status { get; set; }

    }
}
