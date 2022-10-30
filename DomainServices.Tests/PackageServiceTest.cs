using System;
using System.Collections.Generic;
using Domain;
using DomainServices.Repos.Inf;
using DomainServices.Services.Impl;
using DomainServices.Services.Inf;
using Moq;
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
    public void CanPackageBeReservedByStudent_StudentUnderage()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        var studentRepo = new Mock<IStudentRepository>();
        packageRepo.Setup(p => p.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = null
            });

        studentRepo.Setup(s => s.GetStudentById(1)).Returns(
            new Student
            {
                StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
                DateOfBirth = DateTime.Today.AddYears(-17)
            });

        var package = packageRepo.Object.GetPackageById(1);
        var student = studentRepo.Object.GetStudentById(1);

        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package!, student!);
        // Assert
        Assert.False(act);
    }


    [Fact]
    public void CanPackageBeReservedByStudent_StudentEighteenOnDayOfPickup()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        var studentRepo = new Mock<IStudentRepository>();

        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package()
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = null
            });

        studentRepo.Setup(s => s.GetStudentById(1)).Returns(new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Today.AddYears(-18)
        });


        var package = packageRepo.Object.GetPackageById(1);
        var student = studentRepo.Object.GetStudentById(1);
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package!, student!);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentEighteenAfterPickup()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        var studentRepo = new Mock<IStudentRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = null
            });
        studentRepo.Setup(s => s.GetStudentById(1)).Returns(new Student
        {
            StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
            DateOfBirth = DateTime.Today.AddYears(-18).AddDays(1)
        });

        var package = packageRepo.Object.GetPackageById(1);
        var student = studentRepo.Object.GetStudentById(1);
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package!, student!);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentAlreadyExists()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        var studentRepo = new Mock<IStudentRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });
        studentRepo.Setup(s => s.GetStudentById(1)).Returns(
            new Student
            {
                StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
                DateOfBirth = DateTime.Today.AddYears(-19)
            });

        var package = packageRepo.Object.GetPackageById(1);
        var student = studentRepo.Object.GetStudentById(1);
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package!, student!);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentAlreadyReservedAPackageToday()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        var studentRepo = new Mock<IStudentRepository>();
        // Arrange
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        packageRepo.Setup(s => s.GetPackageById(2)).Returns(
            new Package()
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = null
            });
        var package = packageRepo.Object.GetPackageById(1);

        studentRepo.Setup(s => s.GetStudentById(1)).Returns(
            new Student
            {
                StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
                DateOfBirth = DateTime.Today.AddYears(-19), Packages = new List<Package>
                {
                    package!
                }
            });

        var package2 = packageRepo.Object.GetPackageById(2);
        var student = studentRepo.Object.GetStudentById(1);
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package2!, student!);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void CanPackageBeReservedByStudent_StudentReservedYesterday()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        var studentRepo = new Mock<IStudentRepository>();
        // Arrange
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today.AddDays(-1),
                EndTimeSlot = DateTime.Today.AddDays(-1).AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        packageRepo.Setup(s => s.GetPackageById(2)).Returns(
            new Package
        {
            PackageId = 1,
            Name = "Test package",
            CityId = 1,
            City = new City(),
            CafeteriaId = 1,
            Cafeteria = new Cafeteria(),
            Products = new List<Product>(),
            StartTimeSlot = DateTime.Today,
            EndTimeSlot = DateTime.Today.AddHours(3),
            EighteenPlus = true,
            Price = 1.99m,
            Category = Category.Fruit,
            StudentId = null
        });

        var package = packageRepo.Object.GetPackageById(1);
        studentRepo.Setup(s => s.GetStudentById(1)).Returns(
            new Student
            {
                StudentId = 1, EmailAddress = "Underage@gmail.com", CityId = 1, PhoneNumber = "06 58123456",
                DateOfBirth = DateTime.Today.AddYears(-19), Packages = new List<Package>
                {
                    package!
                }
            });

        var package2 = packageRepo.Object.GetPackageById(2);
        var student = studentRepo.Object.GetStudentById(1);
        // Act
        var act = _packageService.CanPackageBeReservedByStudent(package2!, student!);
        // Assert
        Assert.True(act);
    }


    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageYesterday()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today.AddDays(-1),
                EndTimeSlot = DateTime.Today.AddDays(-1).AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        var package = packageRepo.Object.GetPackageById(1);
        // Act
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package!);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageToday()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        var package = packageRepo.Object.GetPackageById(1);

        // Act
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package!);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageTheDayAfterTomorrow()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today.AddDays(2),
                EndTimeSlot = DateTime.Today.AddDays(2).AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });
        // Act
        var package = packageRepo.Object.GetPackageById(1);
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package!);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageDateNotTooFarInTheFutureOrPast_PackageDate3DaysIntoTheFuture()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today.AddDays(3),
                EndTimeSlot = DateTime.Today.AddDays(3).AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        var package = packageRepo.Object.GetPackageById(1);
        // Act
        var act = _packageService.PackageDateNotTooFarInTheFutureOrPast(package!);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageHasCorrectStartAndEnd_SameDayStartLessThanEnd()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today,
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        var package = packageRepo.Object.GetPackageById(1);
        // Act
        var act = _packageService.PackageHasCorrectStartAndEnd(package!);
        // Assert
        Assert.True(act);
    }

    [Fact]
    public void PackageHasCorrectStartAndEnd_SameDayStartLaterThanEnd()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today.AddHours(4),
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        var package = packageRepo.Object.GetPackageById(1);
        // Act
        var act = _packageService.PackageHasCorrectStartAndEnd(package!);
        // Assert
        Assert.False(act);
    }

    [Fact]
    public void PackageHasCorrectStartAndEnd_DifferentDay()
    {
        // Arrange
        var packageRepo = new Mock<IPackageRepository>();
        packageRepo.Setup(s => s.GetPackageById(1)).Returns(
            new Package
            {
                PackageId = 1,
                Name = "Test package",
                CityId = 1,
                City = new City(),
                CafeteriaId = 1,
                Cafeteria = new Cafeteria(),
                Products = new List<Product>(),
                StartTimeSlot = DateTime.Today.AddDays(-1),
                EndTimeSlot = DateTime.Today.AddHours(3),
                EighteenPlus = true,
                Price = 1.99m,
                Category = Category.Fruit,
                StudentId = 1
            });

        var package = packageRepo.Object.GetPackageById(1);
        // Act
        var act = _packageService.PackageHasCorrectStartAndEnd(package!);
        // Assert
        Assert.False(act);
    }
}