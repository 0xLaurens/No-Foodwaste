using System;
using System.Collections.Generic;
using Domain;
using DomainServices.Services.Impl;
using DomainServices.Services.Inf;
using Xunit;

namespace DomainService.Tests;

public class PackageServiceTest
{
    private readonly IPackageService _packageService;

    public PackageServiceTest()
    {
        _packageService = new PackageService();
    }

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
        var act = _packageService.CanPackageBeAltered(package);

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
        var act = _packageService.CanPackageBeAltered(package);

        //Assert
        Assert.True(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentUnderage()
    {
        // Arrange
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = null
        };
        var student = new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Now.AddYears(-17)
        };
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package, student);
        // Assert
        Assert.False(act);
    }


    [Fact]
    public void CanPackageBeReservedByStudent_StudentEighteenOnDayOfPickup()
    {
        // Arrange
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = null
        };
        var student = new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Now.AddYears(-18)
        };
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package, student);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentEighteenAfterPickup()
    {
        // Arrange
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = null
        };
        var student = new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Now.AddYears(-18).AddDays(1)
        };
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package, student);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentAlreadyExists()
    {
        // Arrange
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        var student = new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Now.AddYears(-19)
        };
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package, student);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentAlreadyReservedAPackageToday()
    {
        // Arrange
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };

        var package2 = new Package
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = null
        };

        var student = new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Now.AddYears(-19), Packages = new List<Package>()
            {
                package
            }
        };
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package2, student);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentReservedYesterday()
    {
        // Arrange
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now.AddDays(-1),
            EndTimeSlot = DateTime.Now.AddDays(-1).AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };

        var package2 = new Package
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = null
        };

        var student = new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Now.AddYears(-19), Packages = new List<Package>()
            {
                package
            }
        };
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package2, student);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageHasProductsThatContainsAlcohol_NoProductsThatContainAlcohol()
    {
        // Arrange
        var products = new List<Product>()
        {
            new() { ProductId = 1, Name = "p1", ContainsAlcohol = false, },
            new() { ProductId = 2, Name = "p2", ContainsAlcohol = false, },
            new() { ProductId = 3, Name = "p3", ContainsAlcohol = false, },
            new() { ProductId = 4, Name = "p4", ContainsAlcohol = false, },
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
        var act = _packageService.PackagesHasProductThatContainsAlcohol(package);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageHasProductsThatContainsAlcohol_AProductThatContainsAlcohol()
    {
        // Arrange
        var products = new List<Product>()
        {
            new() { ProductId = 1, Name = "p1", ContainsAlcohol = false, },
            new() { ProductId = 2, Name = "p2", ContainsAlcohol = false, },
            new() { ProductId = 3, Name = "p3", ContainsAlcohol = true, },
            new() { ProductId = 4, Name = "p4", ContainsAlcohol = true, },
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
        var act = _packageService.PackagesHasProductThatContainsAlcohol(package);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageYesterday()
    {
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now.AddDays(-1),
            EndTimeSlot = DateTime.Now.AddDays(-1).AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageToday()
    {
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageTheDayAfterTomorrow()
    {
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now.AddDays(2),
            EndTimeSlot = DateTime.Now.AddDays(2).AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageDate3DaysIntoTheFuture()
    {
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now.AddDays(3),
            EndTimeSlot = DateTime.Now.AddDays(3).AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageHasCorrectStartAndEnd_SameDayStartLessThanEnd()
    {
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
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = _packageService.PackageHasCorrectStartAndEnd(package);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageHasCorrectStartAndEnd_SameDayStartLaterThanEnd()
    {
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now.AddHours(4),
            EndTimeSlot = DateTime.Now.AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = _packageService.PackageHasCorrectStartAndEnd(package);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageHasCorrectStartAndEnd_DifferentDay()
    {
        var package = new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Now.AddDays(-1),
            EndTimeSlot = DateTime.Now.AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = 1
        };
        // Act
        var act = _packageService.PackageHasCorrectStartAndEnd(package);
        // Assert
        Assert.False(act);
    }
}