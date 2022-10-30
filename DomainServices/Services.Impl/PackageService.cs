using Domain;
using DomainServices.Services.Inf;

namespace DomainServices.Services.Impl;

public class PackageService : IPackageService
{
    public bool PackagesHasProductThatContainsAlcohol(Package package)
    {
        return package.Products!.Any(p => p.ContainsAlcohol == true);
    }

    public bool CanPackageBeAltered(Package package)
    {
        return package.StudentId == null;
    }

    public bool StudentCanOrderPackageOnDate(Package package, Student student)
    {
        if (student.Packages == null) return true;
        var count = student.Packages!.Count(p => p.StartTimeSlot.Date == package.StartTimeSlot.Date);
        return count + 1 <= 1;
    }

    public bool CanPackageBeReservedByStudent(Package package, Student student)
    {
        // timespan of 6574 days is 18 year
        return StudentOldEnoughForPackage(package, student)
               && CanPackageBeAltered(package)
               && StudentCanOrderPackageOnDate(package, student);
    }

    public bool StudentOldEnoughForPackage(Package package, Student student)
    {
        return package.StartTimeSlot.Subtract(student.DateOfBirth!.Value.Date) >= new TimeSpan(6574, 0, 0, 0);
    }

   public bool PackageHasCorrectDate(Package package)
    {
        return PackageDateNotTooFarInTheFutureOrPast(package)
               && PackageHasCorrectStartAndEnd(package);
    }

    public bool PackageDateNotTooFarInTheFutureOrPast(Package package)
    {
        return package.StartTimeSlot.Date.Subtract(DateTime.Now.Date.AddDays(2)).TotalDays <= 0
               && package.StartTimeSlot.Date.Subtract(DateTime.Now.Date).Days >= 0;
    }

    public bool PackageHasCorrectStartAndEnd(Package package)
    {
        return package.StartTimeSlot.Date == package.EndTimeSlot.Date
               && DateTime.Compare(package.StartTimeSlot, package.EndTimeSlot) <= 0;
    } 
}