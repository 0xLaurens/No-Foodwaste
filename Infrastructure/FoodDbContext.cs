using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FoodDbContext: DbContext
{
   public FoodDbContext(DbContextOptions options): base(options)
   {
   }

   public DbSet<Cafeteria> Cafeterias { get; set; }
   public DbSet<City> Cities { get; set; }
   public DbSet<Employee> Employees { get; set; }
   public DbSet<Location> Locations { get; set; }
   public DbSet<Package> Packages { get; set; }
   public DbSet<Product> Products { get; set; }
   public DbSet<Student> Students { get; set; }
   
}