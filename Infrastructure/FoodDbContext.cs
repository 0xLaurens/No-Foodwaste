using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FoodDbContext : DbContext
{
   public FoodDbContext(DbContextOptions options) : base(options)
   {
   }

   public DbSet<Cafeteria> Cafeterias { get; set; }
   public DbSet<City> Cities { get; set; }
   public DbSet<Employee> Employees { get; set; }
   public DbSet<Package> Packages { get; set; }
   public DbSet<Product> Products { get; set; }
   public DbSet<Student> Students { get; set; }
   public DbSet<Location> Locations { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder.Entity<Student>().HasData(
         new Student
         {
            StudentId = 1,
            EmailAddress = "Lhh.weterings@student.avans.nl",
            CityId = 1,
            PhoneNumber = "06 58912302",
            DateOfBirth = new DateTime(2003, 01, 19)
         });
      
      modelBuilder.Entity<Product>().HasData(
         new Product { ProductId = 1, Name = "Cheese slice", Photo = "Image of cheese" },
         new Product { ProductId = 2, Name = "Bread", Photo = "Image of Bread" },
         new Product { ProductId = 3, Name = "Ham", Photo = "Image of ham" }
      );
      
      modelBuilder.Entity<Location>().HasData(
         new Location { LocationId = 1, Name = "La", },
         new Location { LocationId = 2, Name = "Ld", },
         new Location { LocationId = 3, Name = "Hl", }
      );
      
      modelBuilder.Entity<City>().HasData(
         new City { CityId = 1, Name = "Breda", Locations =  new List<Location>()});
      modelBuilder.Entity<Employee>().HasData(
         new Employee
         {
            EmployeeId = 1,
            Name = "Harry de Strijder",
            LocationId = 1, 
         },
         new Employee
            {
               EmployeeId = 2,
               Name = "Ankie Bloempot",
               LocationId = 2,
            }
      );
   }
}