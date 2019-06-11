using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Toy> Toy { get; set; }
        public DbSet<ToyType> ToyType { get; set; }
        public DbSet<Clothes> Clothes { get; set; }
        public DbSet<ClothesType> ClothesType { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookType> BookType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser niall = new ApplicationUser
            {
                FirstName = "Niall",
                LastName = "Fraser",
                StreetAddress = "123 Infinity Way",
                UserName = "niall@niall.com",
                NormalizedUserName = "NIALL@NIALL.COM",
                Email = "niall@niall.com",
                NormalizedEmail = "NIALL@NIALL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "4f555f8c-d5db-43b5-836c-aaaaaaaaaaaa",
                Id = "4f555f8c-d5db-43b5-836c-ffffffffffff"
            };
            var passwordHash4 = new PasswordHasher<ApplicationUser>();
            niall.PasswordHash = passwordHash4.HashPassword(niall, "Niall1*");
            modelBuilder.Entity<ApplicationUser>().HasData(niall);
        }
    }
}
