using System.Net.Mime;
using System.Text;
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
        var avansCities = new List<City>()
        {
            new City { CityId = 1, Name = "Breda", Locations = new List<Location>() },
            new City { CityId = 2, Name = "Den Bosch", Locations = new List<Location>() },
            new City { CityId = 3, Name = "Tilburg", Locations = new List<Location>() }
        };

        var locations = new List<Location>()
        {
            new Location
            {
                LocationId = 1, Name = "LA", CityId = 1, Employees = new List<Employee>(),
                Cafeterias = new List<Cafeteria>()
            },
            new Location
            {
                LocationId = 2, Name = "LD", CityId = 2, Employees = new List<Employee>(),
                Cafeterias = new List<Cafeteria>()
            },
            new Location
            {
                LocationId = 3, Name = "HL", CityId = 3, Employees = new List<Employee>(),
                Cafeterias = new List<Cafeteria>()
            }
        };

        var workers = new List<Employee>()
        {
            new Employee
            {
                EmployeeId = 1, Name = "Admin", Email = "admin@avans.nl", LocationId = 1, CafeteriaId = 1,
                CityId = locations[0].CityId
            },
            new Employee
            {
                EmployeeId = 2, Name = "Harry de Strijder", Email = "h.strijder@avans.nl", LocationId = 2,
                CafeteriaId = 2, CityId = locations[1].CityId
            },
            new Employee
            {
                EmployeeId = 3, Name = "Ankie Bloempot", Email = "a.Bloempot", LocationId = 3, CafeteriaId = 3,
                CityId = locations[2].CityId
            }
        };

        var students = new List<Student>()
        {
            new Student
            {
                StudentId = 1, EmailAddress = "student@student.avans.nl", CityId = 1, PhoneNumber = "06 58912302",
                DateOfBirth = new DateTime(2003, 01, 19), Packages = new List<Package>()
            },
            new Student
            {
                StudentId = 2, EmailAddress = "L.pieters@student.avans.nl", CityId = 1, PhoneNumber = "06 38912302",
                DateOfBirth = new DateTime(2001, 11, 30), Packages = new List<Package>()
            },
        };

        var products = new List<Product>()
        {
            new Product
            {
                ProductId = 1, Name = "Cheese slice",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 2, Name = "Ham",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 3, Name = "Banana",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 4, Name = "Orange",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 5, Name = "Chicken",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 6, Name = "Heineken beer",
                Packages = new List<Package>(),
                ContainsAlcohol = true
            },
            new Product
            {
                ProductId = 7, Name = "Pasta Bolognese",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 8, Name = "White Bread",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 9, Name = "Brown Bread",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 10, Name = "Paprika",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 11, Name = "Mayonnaise",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 12, Name = "Ketchup",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 13, Name = "Apple",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 14, Name = "Broccoli",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 15, Name = "Lettuce",
                Packages = new List<Package>(),
                ContainsAlcohol = false
            },
        };

        var cafeterias = new List<Cafeteria>()
        {
            new Cafeteria
            {
                CafeteriaId = 1, CityId = 1, LocationId = locations[0].LocationId, Location = null,
                Packages = new List<Package>()
            },
            new Cafeteria
            {
                CafeteriaId = 2, CityId = 1, LocationId = locations[1].LocationId, Location = null,
                Packages = new List<Package>()
            },
            new Cafeteria
            {
                CafeteriaId = 3, CityId = 1, LocationId = locations[2].LocationId, Location = null,
                Packages = new List<Package>()
            }
        };

        var packages = new List<Package>()
        {
            new Package
            {
                PackageId = 1,
                Name = "Tosti ham 'n cheese",
                Products = new List<Product>(),
                CityId = 1,
                City = null,
                CafeteriaId = 1,
                Cafeteria = null,
                StartTimeSlot = DateTime.Now,
                EndTimeSlot = DateTime.Now.AddHours(3),
                EighteenPlus = false,
                Price = 1.99m,
                Category = Category.Bread,
                StudentId = students.First().StudentId
            },
            new Package
            {
                PackageId = 2,
                Name = "Beer and chicken",
                Products = new List<Product>(),
                CityId = 1,
                City = null,
                CafeteriaId = 1,
                Cafeteria = null,
                StartTimeSlot = DateTime.Now,
                EndTimeSlot = DateTime.Now.AddHours(3),
                EighteenPlus = true,
                Price = 2.99m,
                Category = Category.Bread,
            },
            new Package
            {
                PackageId = 3,
                Name = "Fruit bowl",
                CityId = 1,
                CafeteriaId = 2,
                Cafeteria = null,
                StartTimeSlot = DateTime.Now,
                EndTimeSlot = DateTime.Now.AddHours(3),
                EighteenPlus = false,
                Price = 3.44m,
                Category = Category.Fruit,
                StudentId = null,
                Products = new List<Product>(),
                City = null,
            },
            new Package
            {
                PackageId = 4,
                Name = "Vega delight",
                CityId = 1,
                CafeteriaId = 2,
                Cafeteria = null,
                StartTimeSlot = DateTime.Now,
                EndTimeSlot = DateTime.Now.AddHours(3),
                EighteenPlus = false,
                Price = 1.99m,
                Category = Category.Vega,
                StudentId = null,
                Products = new List<Product>(),
                City = null,
            },
            new Package
            {
                PackageId = 5,
                Name = "Sloppy spaghetti sandwich",
                CityId = 1,
                CafeteriaId = 3,
                Cafeteria = null,
                StartTimeSlot = DateTime.Now,
                EndTimeSlot = DateTime.Now.AddHours(3),
                EighteenPlus = false,
                Price = 2.49m,
                Category = Category.Bread,
                StudentId = null,
                Products = new List<Product>(),
                City = null,
            },
            new Package
            {
                PackageId = 6,
                Name = "Heineken Beer",
                CityId = 1,
                CafeteriaId = 3,
                Cafeteria = null,
                StartTimeSlot = DateTime.Now,
                EndTimeSlot = DateTime.Now.AddHours(3),
                EighteenPlus = true,
                Price = 1m,
                Category = Category.Beveridge,
                StudentId = null,
                Products = new List<Product>(),
                City = null,
            },
        };

        base.OnModelCreating(modelBuilder);
        // Packages 
        modelBuilder.Entity<Package>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Package>()
            .HasOne<Cafeteria>(p => p.Cafeteria);

        modelBuilder.Entity<Package>()
            .HasOne<City>(p => p.City);

        modelBuilder.Entity<Package>()
            .HasMany<Product>(p => p.Products)
            .WithMany(p => p.Packages);

        modelBuilder.Entity<Package>()
            .HasData(packages);

        // products

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasData(products);

        // package product 
        modelBuilder.Entity("PackageProduct")
            .HasData(
                new { PackagesPackageId = 1, ProductsProductId = 1 },
                new { PackagesPackageId = 1, ProductsProductId = 2 },
                new { PackagesPackageId = 1, ProductsProductId = 8 },
                new { PackagesPackageId = 1, ProductsProductId = 12 },
                new { PackagesPackageId = 2, ProductsProductId = 5 },
                new { PackagesPackageId = 2, ProductsProductId = 6 },
                new { PackagesPackageId = 3, ProductsProductId = 3 },
                new { PackagesPackageId = 3, ProductsProductId = 4 },
                new { PackagesPackageId = 3, ProductsProductId = 13 },
                new { PackagesPackageId = 4, ProductsProductId = 10 },
                new { PackagesPackageId = 4, ProductsProductId = 14 },
                new { PackagesPackageId = 4, ProductsProductId = 15 },
                new { PackagesPackageId = 5, ProductsProductId = 7 },
                new { PackagesPackageId = 5, ProductsProductId = 9 },
                new { PackagesPackageId = 6, ProductsProductId = 6 }
            );


        // City
        modelBuilder.Entity<City>().HasData(avansCities);

        //Students
        modelBuilder.Entity<Student>().HasData(students);
        modelBuilder.Entity<Student>()
            .HasIndex(s => s.EmailAddress).IsUnique();

        modelBuilder.Entity<Location>().HasData(locations);
        modelBuilder.Entity<Employee>().HasData(workers);
        modelBuilder.Entity<Cafeteria>().HasData(cafeterias);
    }
}