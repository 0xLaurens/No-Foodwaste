using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests;

public class StudentTest 
{
    [Fact]
    public void DateOfBirth_YoungerThan16()
    {
        // Arrange
        var student = new Student
        {
            StudentId = 1,
            EmailAddress = "email@gmail.com",
            CityId = 1,
            PhoneNumber = "06 5555555555",
            Packages = new List<Package>()
        };
        // Act
        var act = Assert.Throws<InvalidOperationException>(() => student.DateOfBirth = DateTime.Now.AddYears(-15));
        // Assert
        Assert.Equal("Student must be at least 16 years old", act.Message);
        Assert.Null(student.DateOfBirth);
    }
    
    [Fact]
    public void DateOfBirth_BirthdayInTheFuture()
    {
        // Arrange
        var student = new Student
        {
            StudentId = 1,
            EmailAddress = "email@gmail.com",
            CityId = 1,
            PhoneNumber = "06 5555555555",
            Packages = new List<Package>()
        };
        // Act
        var act = Assert.Throws<InvalidOperationException>(() => student.DateOfBirth = DateTime.Now.AddYears(10));
        // Assert
        Assert.Equal("Birthday cannot be in the future", act.Message);
        Assert.Null(student.DateOfBirth);
    }
    
    [Fact]
    public void DateOfBirth_16thBirthdayToday()
    {
         // Arrange
        var student = new Student
        {
            StudentId = 1,
            EmailAddress = "email@gmail.com",
            CityId = 1,
            PhoneNumber = "06 5555555555",
            Packages = new List<Package>(),
            // Act
            DateOfBirth = DateTime.Now.AddYears(-16)
        };
        // Assert
        Assert.Equal( DateTime.Now.AddYears(-16).Date, student.DateOfBirth);
    }
    
    [Fact]
    public void DateOfBirth_OlderThan16()
    {
        // Arrange
        var student = new Student
        {
            StudentId = 1,
            EmailAddress = "email@gmail.com",
            CityId = 1,
            PhoneNumber = "06 5555555555",
            Packages = new List<Package>(),
            // Act
            DateOfBirth = DateTime.Now.AddYears(-19)
        };
        // Assert
        Assert.Equal( DateTime.Now.AddYears(-19).Date, student.DateOfBirth);
    }
    
    
}