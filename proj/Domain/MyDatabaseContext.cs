using Microsoft.EntityFrameworkCore;
using proj.Models.Entities;
using System;

namespace proj.Domain
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<RentalRequest> RentalRequests { get; set; }

        public MyDatabaseContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DBSRV\\ag2025;Initial Catalog=DeysAI2307g1 Project;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<AppSetting>().HasKey(a => a.SettingId);

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();


        }
    }
}
