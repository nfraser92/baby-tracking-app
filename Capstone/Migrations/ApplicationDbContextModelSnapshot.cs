﻿// <auto-generated />
using System;
using Capstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capstone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Capstone.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("BookTypeId");

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsOutgrown");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("UserId");

                    b.HasKey("BookId");

                    b.HasIndex("BookTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Capstone.Models.BookType", b =>
                {
                    b.Property<int>("BookTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("BookTypeId");

                    b.ToTable("BookType");

                    b.HasData(
                        new
                        {
                            BookTypeId = 1,
                            Description = "Musical/Sounds/Nursery Rhymes"
                        },
                        new
                        {
                            BookTypeId = 2,
                            Description = "Animals"
                        },
                        new
                        {
                            BookTypeId = 3,
                            Description = "Activity Books"
                        },
                        new
                        {
                            BookTypeId = 4,
                            Description = "Board Books"
                        },
                        new
                        {
                            BookTypeId = 5,
                            Description = "Counting/Alphabet"
                        },
                        new
                        {
                            BookTypeId = 6,
                            Description = "Coloring"
                        });
                });

            modelBuilder.Entity("Capstone.Models.Clothes", b =>
                {
                    b.Property<int>("ClothesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClothesTypeId");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsOutgrown");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("UserId");

                    b.HasKey("ClothesId");

                    b.HasIndex("ClothesTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("Capstone.Models.ClothesType", b =>
                {
                    b.Property<int>("ClothesTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("UserId");

                    b.HasKey("ClothesTypeId");

                    b.ToTable("ClothesType");

                    b.HasData(
                        new
                        {
                            ClothesTypeId = 1,
                            Description = "Shirts"
                        },
                        new
                        {
                            ClothesTypeId = 2,
                            Description = "Pants"
                        },
                        new
                        {
                            ClothesTypeId = 3,
                            Description = "Shorts"
                        },
                        new
                        {
                            ClothesTypeId = 5,
                            Description = "Socks"
                        },
                        new
                        {
                            ClothesTypeId = 6,
                            Description = "Shoes"
                        },
                        new
                        {
                            ClothesTypeId = 7,
                            Description = "Hats"
                        },
                        new
                        {
                            ClothesTypeId = 8,
                            Description = "Jackets"
                        },
                        new
                        {
                            ClothesTypeId = 9,
                            Description = "Sweaters"
                        });
                });

            modelBuilder.Entity("Capstone.Models.GiftIdeas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId");

                    b.Property<int?>("BookTypeId");

                    b.Property<int?>("ClothesId");

                    b.Property<int?>("ClothesTypeId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ImagePath");

                    b.Property<string>("Size")
                        .HasMaxLength(20);

                    b.Property<int?>("ToyId");

                    b.Property<int?>("ToyTypeId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookTypeId");

                    b.HasIndex("ClothesId");

                    b.HasIndex("ClothesTypeId");

                    b.HasIndex("ToyId");

                    b.HasIndex("ToyTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("GiftIdeas");
                });

            modelBuilder.Entity("Capstone.Models.Toy", b =>
                {
                    b.Property<int>("ToyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImagePath");

                    b.Property<int>("ToyTypeId");

                    b.Property<string>("UserId");

                    b.HasKey("ToyId");

                    b.HasIndex("ToyTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Toy");
                });

            modelBuilder.Entity("Capstone.Models.ToyType", b =>
                {
                    b.Property<int>("ToyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("ToyTypeId");

                    b.ToTable("ToyType");

                    b.HasData(
                        new
                        {
                            ToyTypeId = 1,
                            Description = "Vehicles"
                        },
                        new
                        {
                            ToyTypeId = 2,
                            Description = "Puzzles/Jigsaws"
                        },
                        new
                        {
                            ToyTypeId = 3,
                            Description = "Lego/Blocks"
                        },
                        new
                        {
                            ToyTypeId = 4,
                            Description = "Outdoor"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Capstone.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("StreetAddress");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "4f555f8c-d5db-43b5-836c-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3e9fd402-0da3-4ff6-9b76-40f382e2bde5",
                            Email = "niall@niall.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "NIALL@NIALL.COM",
                            NormalizedUserName = "NIALL@NIALL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFqXtcTSsFJQKPqyaadfML64j2mvnfoQZ+B5xqT5sSbuX+b1Iv04gYmku6HXRu0QUw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4f555f8c-d5db-43b5-836c-aaaaaaaaaaaa",
                            TwoFactorEnabled = false,
                            UserName = "niall@niall.com",
                            FirstName = "Niall",
                            LastName = "Fraser",
                            StreetAddress = "123 Infinity Way"
                        });
                });

            modelBuilder.Entity("Capstone.Models.Book", b =>
                {
                    b.HasOne("Capstone.Models.BookType", "BookType")
                        .WithMany("Books")
                        .HasForeignKey("BookTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Capstone.Models.ApplicationUser", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Capstone.Models.Clothes", b =>
                {
                    b.HasOne("Capstone.Models.ClothesType", "ClothesType")
                        .WithMany("Clothes")
                        .HasForeignKey("ClothesTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Capstone.Models.ApplicationUser", "User")
                        .WithMany("Clothes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Capstone.Models.GiftIdeas", b =>
                {
                    b.HasOne("Capstone.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Capstone.Models.BookType", "BookType")
                        .WithMany()
                        .HasForeignKey("BookTypeId");

                    b.HasOne("Capstone.Models.Clothes", "Clothes")
                        .WithMany()
                        .HasForeignKey("ClothesId");

                    b.HasOne("Capstone.Models.ClothesType", "ClothesType")
                        .WithMany()
                        .HasForeignKey("ClothesTypeId");

                    b.HasOne("Capstone.Models.Toy", "Toy")
                        .WithMany()
                        .HasForeignKey("ToyId");

                    b.HasOne("Capstone.Models.ToyType", "ToyType")
                        .WithMany()
                        .HasForeignKey("ToyTypeId");

                    b.HasOne("Capstone.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Capstone.Models.Toy", b =>
                {
                    b.HasOne("Capstone.Models.ToyType", "ToyType")
                        .WithMany("Toys")
                        .HasForeignKey("ToyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Capstone.Models.ApplicationUser", "User")
                        .WithMany("Toys")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
