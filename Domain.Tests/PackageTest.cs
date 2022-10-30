using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests;

public class PackageTest
{
    [Fact]
    public void CanPackageBeAltered_StudentNotNull()
    {
        //Arrange
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now,
            EndTimeSlot = DateTime.Now.AddHours(3),
            EighteenPlus = false,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        //Act
        var act = package.CanPackageBeAltered();

        //Assert
        Assert.False(act);
    }

    [Fact]
    public void CanPackageBeAltered_StudentEqualsNull()
    {
        //Arrange
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now,
            EndTimeSlot = DateTime.Now.AddHours(3),
            EighteenPlus = false,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = null
        };
        //Act
        var act = package.CanPackageBeAltered();

        //Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageHasProductsThatContainsAlcohol_NoProductsThatContainAlcohol()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { ProductId = 1, Name = "p1", ContainsAlcohol = false },
            new() { ProductId = 2, Name = "p2", ContainsAlcohol = false },
            new() { ProductId = 3, Name = "p3", ContainsAlcohol = false },
            new() { ProductId = 4, Name = "p4", ContainsAlcohol = false }
        };
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = products,
            StartTimeSlot = DateTime.Now,
            EndTimeSlot = DateTime.Now.AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = package.PackagesHasProductThatContainsAlcohol();
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageHasProductsThatContainsAlcohol_AProductThatContainsAlcohol()
    {
        // Arrange
        var products = new List<Product>
        {
            new() { ProductId = 1, Name = "p1", ContainsAlcohol = false },
            new() { ProductId = 2, Name = "p2", ContainsAlcohol = false },
            new() { ProductId = 3, Name = "p3", ContainsAlcohol = true },
            new() { ProductId = 4, Name = "p4", ContainsAlcohol = true }
        };
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = products,
            StartTimeSlot = DateTime.Now,
            EndTimeSlot = DateTime.Now.AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = package.PackagesHasProductThatContainsAlcohol();
        // Assert
        Assert.True(act);
    }
    
    
}