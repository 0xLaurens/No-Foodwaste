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
        if (student.Packages == null)
        {
            return true;
        }
        var count = student.Packages!.Count(p => p.PickupTime.Date == package.PickupTime.Date);
        return count + 1 <= 1;
    }
    
    public bool CanPackageBeReservedByStudent(Package package, Student student)
    {
        return package.PickupTime.Date.Subtract(student.DateOfBirth!.Value.Date) >= new TimeSpan(6574, 0, 0, 0)
               && CanPackageBeAltered(package)
               && StudentCanOrderPackageOnDate(package, student);
    }

    public bool PackageHasCorrectDate(Package package)
    {
        return (package.PickupTime - DateTime.Now.AddDays(2)).TotalDays <= 0 
               && package.PickupTime <= package.BestBeforeDate;
    }
}