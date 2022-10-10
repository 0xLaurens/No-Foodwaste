using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FoodDbContext : DbContext
{
   public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
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
      
      var avansCities = new List<City>()
      {
         new City { CityId = 1, Name = "Breda", Locations = new List<Location>()},
         new City { CityId = 2, Name = "Den Bosch", Locations = new List<Location>()},
         new City { CityId = 3, Name = "Tilburg", Locations = new List<Location>()}
      };
      
      var locations = new List<Location>()
      {
         new Location { LocationId = 1, Name = "La", CityId = 1, Employees = new List<Employee>()},
         new Location { LocationId = 2, Name = "Ld", CityId = 2, Employees = new List<Employee>()},
         new Location { LocationId = 3, Name = "Hl", CityId = 3, Employees = new List<Employee>()}
      };
      
      var students = new List<Student>()
      {
         new Student { StudentId = 1, EmailAddress = "Lhh.weterings@student.avans.nl", CityId = 1, PhoneNumber = "06 58912302", DateOfBirth = new DateTime(2003, 01, 19) },
         new Student { StudentId = 2, EmailAddress = "L.pieters@student.avans.nl", CityId = 1, PhoneNumber = "06 38912302", DateOfBirth = new DateTime(2001, 11, 30) },
      };

      var products = new List<Product>()
      {
         new Product { ProductId = 1, Name = "Cheese slice", Photo = "Image of cheese", Packages = new List<Package>()},
         new Product { ProductId = 2, Name = "Bread", Photo = "Image of Bread", Packages = new List<Package>()},
         new Product { ProductId = 3, Name = "Ham", Photo = "Image of ham", Packages = new List<Package>()}
      };
      
       var cafeterias = new List<Cafeteria>()
      {
         new Cafeteria { CafeteriaId = 1, CityId = 1, Packages = new List<Package>()},
         new Cafeteria { CafeteriaId = 2, CityId = 1, Packages = new List<Package>()}
      };
 
      var packages = new List<Package>()
      {
         new Package
         {
            PackageId = 1,
            Name = "Broodpakket",
            Products = new List<Product>(),
            CityId = 1,
            CafeteriaId = 1, 
            PickupTime = DateTime.Today.AddDays(1),
            BestBeforeDate = DateTime.Today.AddDays(2),
            EighteenPlus = false,
            Price = 1.99m,
            Category = Category.Bread,
            ReservedByStudentId = students.First().StudentId
         },
         new Package
         {
            PackageId = 2,
            Name = "Pretpakket",
            Products = new List<Product>(),
            CityId = 1,
            CafeteriaId = 1, 
            PickupTime = DateTime.Today.AddDays(1),
            BestBeforeDate = DateTime.Today.AddDays(2),
            EighteenPlus = true,
            Price = 20.99m,
            Category = Category.Bread,
            ReservedByStudentId = null, 
         }
      };
      
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Package>().HasData(packages);
      modelBuilder.Entity<City>().HasData(avansCities);
      modelBuilder.Entity<Student>().HasData(students);
      modelBuilder.Entity<Product>().HasData(products);
      modelBuilder.Entity<Location>().HasData(locations);
      modelBuilder.Entity<Employee>().HasData(workers);
      modelBuilder.Entity<Cafeteria>().HasData(cafeterias);
   }
}