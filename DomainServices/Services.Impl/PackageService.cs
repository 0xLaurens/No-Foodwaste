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
        return package.ReservedByStudentId == null;
    }

    public bool CanPackageBeReservedByStudent(Package package, Student student)
    {
        return student.DateOfBirth!.Value.Subtract(package.PickupTime) >= TimeSpan.Zero 
               && CanPackageBeAltered(package);
    }

    public bool PackageHasCorrectDate(Package package)
    {
        return (package.PickupTime - DateTime.Now.AddDays(2)).TotalDays <= 0 
               && package.PickupTime <= package.BestBeforeDate;
    }
}