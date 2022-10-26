﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(FoodDbContext))]
    partial class FoodDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Cafeteria", b =>
                {
                    b.Property<int>("CafeteriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CafeteriaId"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("CafeteriaId");

                    b.HasIndex("CityId");

                    b.HasIndex("LocationId");

                    b.ToTable("Cafeterias");

                    b.HasData(
                        new
                        {
                            CafeteriaId = 1,
                            CityId = 1,
                            LocationId = 1
                        },
                        new
                        {
                            CafeteriaId = 2,
                            CityId = 1,
                            LocationId = 2
                        },
                        new
                        {
                            CafeteriaId = 3,
                            CityId = 1,
                            LocationId = 3
                        });
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            Name = "Breda"
                        },
                        new
                        {
                            CityId = 2,
                            Name = "Den Bosch"
                        },
                        new
                        {
                            CityId = 3,
                            Name = "Tilburg"
                        });
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("CafeteriaId")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("LocationId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            CafeteriaId = 1,
                            CityId = 1,
                            Email = "admin@avans.nl",
                            LocationId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            EmployeeId = 2,
                            CafeteriaId = 2,
                            CityId = 2,
                            Email = "h.strijder@avans.nl",
                            LocationId = 2,
                            Name = "Harry de Strijder"
                        },
                        new
                        {
                            EmployeeId = 3,
                            CafeteriaId = 3,
                            CityId = 3,
                            Email = "a.Bloempot",
                            LocationId = 3,
                            Name = "Ankie Bloempot"
                        });
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("CityId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            CityId = 1,
                            Name = "LA"
                        },
                        new
                        {
                            LocationId = 2,
                            CityId = 2,
                            Name = "LD"
                        },
                        new
                        {
                            LocationId = 3,
                            CityId = 3,
                            Name = "HL"
                        });
                });

            modelBuilder.Entity("Domain.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"), 1L, 1);

                    b.Property<int>("CafeteriaId")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("EighteenPlus")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndTimeSlot")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("Decimal(3,2)");

                    b.Property<DateTime>("StartTimeSlot")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("PackageId");

                    b.HasIndex("CafeteriaId");

                    b.HasIndex("CityId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("StudentId");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            PackageId = 1,
                            CafeteriaId = 1,
                            Category = 1,
                            CityId = 1,
                            EighteenPlus = false,
                            EndTimeSlot = new DateTime(2022, 10, 26, 14, 17, 50, 644, DateTimeKind.Local).AddTicks(6867),
                            Name = "Tosti ham 'n cheese",
                            Price = 1.99m,
                            StartTimeSlot = new DateTime(2022, 10, 26, 11, 17, 50, 644, DateTimeKind.Local).AddTicks(6853),
                            StudentId = 1
                        },
                        new
                        {
                            PackageId = 2,
                            CafeteriaId = 1,
                            Category = 1,
                            CityId = 1,
                            EighteenPlus = true,
                            EndTimeSlot = new DateTime(2022, 10, 26, 14, 17, 50, 644, DateTimeKind.Local).AddTicks(6910),
                            Name = "Beer and chicken",
                            Price = 2.99m,
                            StartTimeSlot = new DateTime(2022, 10, 26, 11, 17, 50, 644, DateTimeKind.Local).AddTicks(6895)
                        },
                        new
                        {
                            PackageId = 3,
                            CafeteriaId = 2,
                            Category = 0,
                            CityId = 1,
                            EighteenPlus = false,
                            EndTimeSlot = new DateTime(2022, 10, 26, 14, 17, 50, 644, DateTimeKind.Local).AddTicks(6939),
                            Name = "Fruit bowl",
                            Price = 3.44m,
                            StartTimeSlot = new DateTime(2022, 10, 26, 11, 17, 50, 644, DateTimeKind.Local).AddTicks(6924)
                        },
                        new
                        {
                            PackageId = 4,
                            CafeteriaId = 2,
                            Category = 5,
                            CityId = 1,
                            EighteenPlus = false,
                            EndTimeSlot = new DateTime(2022, 10, 26, 14, 17, 50, 644, DateTimeKind.Local).AddTicks(6967),
                            Name = "Vega delight",
                            Price = 1.99m,
                            StartTimeSlot = new DateTime(2022, 10, 26, 11, 17, 50, 644, DateTimeKind.Local).AddTicks(6952)
                        },
                        new
                        {
                            PackageId = 5,
                            CafeteriaId = 3,
                            Category = 1,
                            CityId = 1,
                            EighteenPlus = false,
                            EndTimeSlot = new DateTime(2022, 10, 26, 14, 17, 50, 644, DateTimeKind.Local).AddTicks(6991),
                            Name = "Sloppy spaghetti sandwich",
                            Price = 2.49m,
                            StartTimeSlot = new DateTime(2022, 10, 26, 11, 17, 50, 644, DateTimeKind.Local).AddTicks(6977)
                        },
                        new
                        {
                            PackageId = 6,
                            CafeteriaId = 3,
                            Category = 4,
                            CityId = 1,
                            EighteenPlus = true,
                            EndTimeSlot = new DateTime(2022, 10, 26, 14, 17, 50, 644, DateTimeKind.Local).AddTicks(7025),
                            Name = "Heineken Beer",
                            Price = 1m,
                            StartTimeSlot = new DateTime(2022, 10, 26, 11, 17, 50, 644, DateTimeKind.Local).AddTicks(7010)
                        });
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<bool?>("ContainsAlcohol")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ContainsAlcohol = false,
                            Name = "Cheese slice",
                            Photo = "Image of cheese"
                        },
                        new
                        {
                            ProductId = 2,
                            ContainsAlcohol = false,
                            Name = "Ham",
                            Photo = "Image of ham"
                        },
                        new
                        {
                            ProductId = 3,
                            ContainsAlcohol = false,
                            Name = "Banana",
                            Photo = "Image of banana"
                        },
                        new
                        {
                            ProductId = 4,
                            ContainsAlcohol = false,
                            Name = "Orange",
                            Photo = "Image of Orange"
                        },
                        new
                        {
                            ProductId = 5,
                            ContainsAlcohol = false,
                            Name = "Chicken",
                            Photo = "Image of chicken"
                        },
                        new
                        {
                            ProductId = 6,
                            ContainsAlcohol = true,
                            Name = "Heineken beer",
                            Photo = "Image of Heineken"
                        },
                        new
                        {
                            ProductId = 7,
                            ContainsAlcohol = false,
                            Name = "Pasta Bolognese",
                            Photo = "Image of Pasta Bolognese"
                        },
                        new
                        {
                            ProductId = 8,
                            ContainsAlcohol = false,
                            Name = "White Bread",
                            Photo = "Image of brood"
                        },
                        new
                        {
                            ProductId = 9,
                            ContainsAlcohol = false,
                            Name = "Brown Bread",
                            Photo = "Image of brood"
                        },
                        new
                        {
                            ProductId = 10,
                            ContainsAlcohol = false,
                            Name = "Paprika",
                            Photo = "Image of Paprika"
                        },
                        new
                        {
                            ProductId = 11,
                            ContainsAlcohol = false,
                            Name = "Mayonaise",
                            Photo = "Image of Mayonaise"
                        },
                        new
                        {
                            ProductId = 12,
                            ContainsAlcohol = false,
                            Name = "Ketchup",
                            Photo = "Image of Ketchup"
                        },
                        new
                        {
                            ProductId = 13,
                            ContainsAlcohol = false,
                            Name = "Apple",
                            Photo = "Image of apple"
                        },
                        new
                        {
                            ProductId = 14,
                            ContainsAlcohol = false,
                            Name = "Broccoli",
                            Photo = "Image of Broccoli"
                        },
                        new
                        {
                            ProductId = 15,
                            ContainsAlcohol = false,
                            Name = "Lettuce",
                            Photo = "Image of Lettuce"
                        });
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("CityId");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasFilter("[EmailAddress] IS NOT NULL");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            CityId = 1,
                            DateOfBirth = new DateTime(2003, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "student@student.avans.nl",
                            PhoneNumber = "06 58912302"
                        },
                        new
                        {
                            StudentId = 2,
                            CityId = 1,
                            DateOfBirth = new DateTime(2001, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "L.pieters@student.avans.nl",
                            PhoneNumber = "06 38912302"
                        });
                });

            modelBuilder.Entity("PackageProduct", b =>
                {
                    b.Property<int>("PackagesPackageId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("PackagesPackageId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("PackageProduct");

                    b.HasData(
                        new
                        {
                            PackagesPackageId = 1,
                            ProductsProductId = 1
                        },
                        new
                        {
                            PackagesPackageId = 1,
                            ProductsProductId = 2
                        },
                        new
                        {
                            PackagesPackageId = 1,
                            ProductsProductId = 8
                        },
                        new
                        {
                            PackagesPackageId = 1,
                            ProductsProductId = 12
                        },
                        new
                        {
                            PackagesPackageId = 2,
                            ProductsProductId = 5
                        },
                        new
                        {
                            PackagesPackageId = 2,
                            ProductsProductId = 6
                        },
                        new
                        {
                            PackagesPackageId = 3,
                            ProductsProductId = 3
                        },
                        new
                        {
                            PackagesPackageId = 3,
                            ProductsProductId = 4
                        },
                        new
                        {
                            PackagesPackageId = 3,
                            ProductsProductId = 13
                        },
                        new
                        {
                            PackagesPackageId = 4,
                            ProductsProductId = 10
                        },
                        new
                        {
                            PackagesPackageId = 4,
                            ProductsProductId = 14
                        },
                        new
                        {
                            PackagesPackageId = 4,
                            ProductsProductId = 15
                        },
                        new
                        {
                            PackagesPackageId = 5,
                            ProductsProductId = 7
                        },
                        new
                        {
                            PackagesPackageId = 5,
                            ProductsProductId = 9
                        },
                        new
                        {
                            PackagesPackageId = 6,
                            ProductsProductId = 6
                        });
                });

            modelBuilder.Entity("Domain.Cafeteria", b =>
                {
                    b.HasOne("Domain.City", null)
                        .WithMany("Cafeterias")
                        .HasForeignKey("CityId");

                    b.HasOne("Domain.Location", "Location")
                        .WithMany("Cafeterias")
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Employee", b =>
                {
                    b.HasOne("Domain.Location", null)
                        .WithMany("Employees")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.HasOne("Domain.City", null)
                        .WithMany("Locations")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("Domain.Package", b =>
                {
                    b.HasOne("Domain.Cafeteria", "Cafeteria")
                        .WithMany("Packages")
                        .HasForeignKey("CafeteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("Domain.Student", null)
                        .WithMany("Packages")
                        .HasForeignKey("StudentId");

                    b.Navigation("Cafeteria");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.HasOne("Domain.City", null)
                        .WithMany("Students")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("PackageProduct", b =>
                {
                    b.HasOne("Domain.Package", null)
                        .WithMany()
                        .HasForeignKey("PackagesPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Cafeteria", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Domain.City", b =>
                {
                    b.Navigation("Cafeterias");

                    b.Navigation("Locations");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.Navigation("Cafeterias");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Student", b =>
                {
                    b.Navigation("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}
