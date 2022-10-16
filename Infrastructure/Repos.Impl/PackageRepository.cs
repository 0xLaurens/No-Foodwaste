using Domain;
using DomainServices.Repos.Inf;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.Impl;

public class PackageRepository : IPackageRepository
{
    private readonly FoodDbContext _context;

    public PackageRepository(FoodDbContext context)
    {
        _context = context;
    }
    public Package GetPackageById(int id)
    {
        return _context.Packages.SingleOrDefault(p => p.PackageId == id);
    }

    public List<Package> GetPackages()
    {
        return _context.Packages
            .OrderBy(p => p.BestBeforeDate)
            .ToList();
    }

    public List<Package> GetNonReservedPackages()
    {
        return GetPackages()
            .Where(p => p.ReservedByStudentId == null)
            .ToList();
    }
    
    public List<Package> GetNonReservedPackagesPerCafeteria(int id)
    {
        return GetNonReservedPackages()
            .Where(p => p.CafeteriaId == id)
            .ToList();
    }

    public List<Package> GetPackagesByStudent(int studentId)
    {
        return GetPackages()
            .Where(p => p.ReservedByStudentId == studentId)
            .ToList();
    }

    public void CreatePackage(Package package)
    {
        _context.Packages.Add(package);
        _context.SaveChanges();
    }

    public void UpdatePackage(Package package)
    {
        var entry = GetPackageById(package.PackageId);
        if (entry == null) throw new NullReferenceException();
        
        _context.Entry(entry).CurrentValues.SetValues(package);
        _context.SaveChanges();
    }

    public void RemovePackage(int id)
    {
        
        var entry = GetPackageById(id);
        if (entry == null) throw new NullReferenceException();
        _context.SaveChanges();
    }
}