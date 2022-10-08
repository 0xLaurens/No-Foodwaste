using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FoodDbContext : DbContext
{
   public FoodDbContext(DbContextOptions options) : base(options)
   {
   }

   public DbSet<Cafeteria>? Cafeterias { get; set; }
   public DbSet<City>? Cities { get; set; }
   public DbSet<Employee>? Employees { get; set; }
   public DbSet<Package>? Packages { get; set; }
   public DbSet<Product>? Products { get; set; }
   public DbSet<Student>? Students { get; set; }
   public DbSet<Location>? Locations { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      var workers = new List<Employee>()
      {
         new Employee { EmployeeId = 1, Name = "Harry de Strijder",  LocationId = 2,},
         new Employee { EmployeeId = 2, Name = "Ankie Bloempot",  LocationId = 1, }
      };
      
      var locations = new List<Location>()
      {
         new Location { LocationId = 1, Name = "La", CityId = 1, Employees = new List<Employee>() },
         new Location { LocationId = 2, Name = "Ld", CityId = 1, Employees = new List<Employee>()},
         new Location { LocationId = 3, Name = "Hl", CityId = 1, Employees = new List<Employee>()}
      };
      
      var cafeterias = new List<Cafeteria>()
      {
         new Cafeteria { CafeteriaId = 1, CityId = 1, },
         new Cafeteria { CafeteriaId = 2, CityId = 1, }
      };
      
      var avansCities = new List<City>()
      {
         new City { CityId = 1, Name = "Breda", Locations = new List<Location>()},
         new City { CityId = 2, Name = "Den Bosch", Locations = new List<Location>()}
      };

      var students = new List<Student>()
      {
         new Student { StudentId = 1, EmailAddress = "Lhh.weterings@student.avans.nl", CityId = 1, PhoneNumber = "06 58912302", DateOfBirth = new DateTime(2003, 01, 19) },
         new Student { StudentId = 2, EmailAddress = "L.pieters@student.avans.nl", CityId = 1, PhoneNumber = "06 38912302", DateOfBirth = new DateTime(2001, 11, 30) },
      };

      var products = new List<Product>()
      {
         new Product { ProductId = 1, Name = "Cheese slice", Photo = "Image of cheese" },
         new Product { ProductId = 2, Name = "Bread", Photo = "Image of Bread" },
         new Product { ProductId = 3, Name = "Ham", Photo = "Image of ham" }
      };

      

      


      
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<City>().HasData(avansCities);
      modelBuilder.Entity<Student>().HasData(students);
      modelBuilder.Entity<Product>().HasData(products);
      modelBuilder.Entity<Location>().HasData(locations);
      modelBuilder.Entity<Employee>().HasData(workers);
      modelBuilder.Entity<Cafeteria>().HasData(cafeterias);
   }
}