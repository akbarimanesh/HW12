using HW12.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Counfiguer.Connectionstring);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskUser>().Property(x => x.Title).HasMaxLength(50);
            modelBuilder.Entity<TaskUser>().Property(x => x.Description).HasMaxLength(4000);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<TaskUser> taskUser { get; set; }
    }
}
