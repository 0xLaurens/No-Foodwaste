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
                LocationId = 1, Name = "La", CityId = 1, Employees = new List<Employee>(),
                Cafeterias = new List<Cafeteria>()
            },
            new Location
            {
                LocationId = 2, Name = "Ld", CityId = 2, Employees = new List<Employee>(),
                Cafeterias = new List<Cafeteria>()
            },
            new Location
            {
                LocationId = 3, Name = "Hl", CityId = 3, Employees = new List<Employee>(),
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
                ProductId = 1, Name = "Cheese slice", Photo = "Image of cheese", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 3, Name = "Ham", Photo = "Image of ham", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 4, Name = "Banana", Photo = "Image of banana", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 5, Name = "Orange", Photo = "Image of Orange", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 6, Name = "Chicken", Photo = "Image of chicken", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 7, Name = "Heineken beer", Photo = "Image of Heineken", Packages = new List<Package>(),
                ContainsAlcohol = true
            },
            new Product
            {
                ProductId = 8, Name = "Pasta Bolognese", Photo = "Image of Pasta Bolognese",
                Packages = new List<Package>(), ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 9, Name = "Bruin brood", Photo = "Image of brood", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 10, Name = "Wit brood", Photo = "Image of brood", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 11, Name = "Paprika", Photo = "Image of Paprika", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 12, Name = "Mayonaise", Photo = "Image of Mayonaise", Packages = new List<Package>(),
                ContainsAlcohol = false
            },
            new Product
            {
                ProductId = 13, Name = "Ketchup", Photo = "Image of Ketchup", Packages = new List<Package>(),
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
                Name = "Broodpakket",
                Products = new List<Product>(),
                CityId = 1,
                City = null,
                CafeteriaId = 1,
                Cafeteria = null,
                PickupTime = DateTime.Today.AddDays(1),
                BestBeforeDate = DateTime.Today.AddDays(2),
                EighteenPlus = false,
                Price = 1.99m,
                Category = Category.Bread,
                StudentId = students.First().StudentId
            },
            new Package
            {
                PackageId = 2,
                Name = "Pretpakket",
                Products = new List<Product>(),
                CityId = 1,
                City = null,
                CafeteriaId = 1,
                Cafeteria = null,
                PickupTime = DateTime.Today.AddDays(1),
                BestBeforeDate = DateTime.Today.AddDays(2),
                EighteenPlus = true,
                Price = 2.99m,
                Category = Category.Bread,
            },
            new Package
            {
                PackageId = 3,
                Name = "Fruit bowl",
                CityId = 1,
                CafeteriaId = 3,
                Cafeteria = null,
                PickupTime = DateTime.Now.AddDays(1),
                BestBeforeDate = DateTime.Now.AddDays(2),
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
                PickupTime = DateTime.Today.AddDays(1),
                BestBeforeDate = DateTime.Today.AddDays(2),
                EighteenPlus = false,
                Price = 1.99m,
                Category = Category.Vega,
                StudentId = students[0].StudentId,
                Products = new List<Product>(),
                City = null,
            },
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