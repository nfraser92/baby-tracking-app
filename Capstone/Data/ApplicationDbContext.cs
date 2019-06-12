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

            modelBuilder.Entity<BookType>().HasData(
                new BookType()
                {
                    BookTypeId = 1,
                    Description = "Musical/Sounds/Nursery Rhymes",
                },
                new BookType()
                {
                    BookTypeId = 2,
                    Description = "Nature",
                },
                 new BookType()
                 {
                     BookTypeId = 3,
                     Description = "Activity Books",
                 },
                  new BookType()
                  {
                      BookTypeId = 4,
                      Description = "Board Books",
                  },
                   new BookType()
                   {
                       BookTypeId = 5,
                       Description = "Learning",
                   }
                );

            modelBuilder.Entity<ToyType>().HasData(
               new ToyType()
               {
                   ToyTypeId = 1,
                   Description = "Vehicles"
               },
               new ToyType()
               {
                   ToyTypeId = 2,
                   Description = "Puzzles/Jigsaws"
               },
               new ToyType()
               {
                   ToyTypeId = 3,
                   Description = "Lego/Blocks"
               },
               new ToyType()
               {
                   ToyTypeId = 4,
                   Description = "Outdoor"
               }

               ); modelBuilder.Entity<ClothesType>().HasData(
               new ClothesType()
               {
                   ClothesTypeId = 1,
                   Description = "Shirts"
               },
               new ClothesType()
               {
                   ClothesTypeId = 2,
                   Description = "Pants"
               },
               new ClothesType()
               {
                   ClothesTypeId = 3,
                   Description = "Shorts"
               },
               new ClothesType()
               {
                   ClothesTypeId = 5,
                   Description = "Socks"
               },
               new ClothesType()
               {
                   ClothesTypeId = 6,
                   Description = "Shoes"
               },
               new ClothesType()
               {
                   ClothesTypeId = 7,
                   Description = "Hats"
               },
               new ClothesType()
               {
                   ClothesTypeId = 8,
                   Description = "Jackets"
               },
               new ClothesType()
               {
                   ClothesTypeId = 9,
                   Description = "Sweaters"
               }
               );


        }

        public DbSet<Capstone.Models.GiftIdeas> GiftIdeas { get; set; }
    }
}
