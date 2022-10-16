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
                            Name = "La"
                        },
                        new
                        {
                            LocationId = 2,
                            CityId = 2,
                            Name = "Ld"
                        },
                        new
                        {
                            LocationId = 3,
                            CityId = 3,
                            Name = "Hl"
                        });
                });

            modelBuilder.Entity("Domain.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"), 1L, 1);

                    b.Property<DateTime?>("BestBeforeDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("CafeteriaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("EighteenPlus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PickupTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReservedByStudentId")
                        .HasColumnType("int");

                    b.HasKey("PackageId");

                    b.HasIndex("CafeteriaId");

                    b.HasIndex("CityId");

                    b.ToTable("Packages");

                    b.HasData(
                        new
                        {
                            PackageId = 1,
                            BestBeforeDate = new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            CafeteriaId = 1,
                            Category = 2,
                            CityId = 1,
                            EighteenPlus = false,
                            Name = "Broodpakket",
                            PickupTime = new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Price = 1.99m,
                            ReservedByStudentId = 1
                        },
                        new
                        {
                            PackageId = 2,
                            BestBeforeDate = new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            CafeteriaId = 1,
                            Category = 2,
                            CityId = 1,
                            EighteenPlus = true,
                            Name = "Pretpakket",
                            PickupTime = new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Price = 20.99m
                        },
                        new
                        {
                            PackageId = 3,
                            BestBeforeDate = new DateTime(2022, 10, 17, 10, 3, 27, 400, DateTimeKind.Local).AddTicks(5431),
                            CafeteriaId = 3,
                            Category = 0,
                            CityId = 1,
                            EighteenPlus = false,
                            Name = "Fruit bowl",
                            PickupTime = new DateTime(2022, 10, 16, 10, 3, 27, 400, DateTimeKind.Local).AddTicks(5427),
                            Price = 3.44m
                        },
                        new
                        {
                            PackageId = 4,
                            BestBeforeDate = new DateTime(2022, 10, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            CafeteriaId = 2,
                            Category = 7,
                            CityId = 1,
                            EighteenPlus = false,
                            Name = "Vega delight",
                            PickupTime = new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            Price = 1.99m,
                            ReservedByStudentId = 1
                        });
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Cheese slice",
                            Photo = "Image of cheese"
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Bread",
                            Photo = "Image of Bread"
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Ham",
                            Photo = "Image of ham"
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Banana",
                            Photo = "Image of banana"
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "Orange",
                            Photo = "Image of Orange"
                        },
                        new
                        {
                            ProductId = 6,
                            Name = "Chicken",
                            Photo = "Image of chicken"
                        },
                        new
                        {
                            ProductId = 7,
                            Name = "Heineken beer",
                            Photo = "Image of Heineken"
                        },
                        new
                        {
                            ProductId = 8,
                            Name = "Pasta Bolognese",
                            Photo = "Image of Pasta Bolognese"
                        },
                        new
                        {
                            ProductId = 9,
                            Name = "Bruin brood",
                            Photo = "Image of brood"
                        },
                        new
                        {
                            ProductId = 10,
                            Name = "Wit brood",
                            Photo = "Image of brood"
                        },
                        new
                        {
                            ProductId = 11,
                            Name = "Paprika",
                            Photo = "Image of Paprika"
                        },
                        new
                        {
                            ProductId = 12,
                            Name = "Mayonaise",
                            Photo = "Image of Mayonaise"
                        },
                        new
                        {
                            ProductId = 13,
                            Name = "Ketchup",
                            Photo = "Image of Ketchup"
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("CityId");

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
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
#pragma warning restore 612, 618
        }
    }
}
