using Domain;
using DomainServices.Repos.Inf;
using DomainServices.Services.Inf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Repos.Impl;

public class PackageRepository : IPackageRepository
{
    private readonly FoodDbContext _context;
    private readonly IPackageService _packageService;

    public PackageRepository(FoodDbContext context, IPackageService packageService)
    {
        _context = context;
        _packageService = packageService;
    }
    public Package GetPackageById(int id)
    {
        return _context.Packages.SingleOrDefault(p => p.PackageId == id);
    }

    public List<Package> GetPackages()
    {
        return _context.Packages!
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
        if (!_packageService.PackageHasCorrectDate(package)) throw new InvalidOperationException();
        _context.Packages?.Add(package);
        _context.SaveChanges();
    }

    public void UpdatePackage(Package package)
    {
        var entry = GetPackageById(package.PackageId);
        if (!_packageService.CanPackageBeAltered(entry)) 
            throw new InvalidOperationException("Cannot be altered");
        if (!_packageService.PackageHasCorrectDate(package))
            throw new InvalidOperationException("Wrong date");

        // Explicit deletion of all foreign keys
        entry.Products!.Any(p => entry.Products!.Remove(p));
        
        
        entry.Products = package.Products; 
        _context.Entry(entry).CurrentValues.SetValues(package);
        _context.SaveChanges();
    }

    public void ReservePackageForStudent(Package package, Student student)
    {
        if (!_packageService.CanPackageBeAltered(package)) 
            throw new InvalidOperationException("Cannot be altered");
        if (!_packageService.PackageHasCorrectDate(package))
            throw new InvalidOperationException("Wrong date");
        
        package.ReservedByStudentId = student.StudentId;
        _context.SaveChanges();
    }

    public void RemovePackage(int id)
    {
        var entry = GetPackageById(id);
        if (!_packageService.CanPackageBeAltered(entry)) 
            throw new InvalidOperationException();
        _context.Packages?.Remove(entry);
        _context.SaveChanges();
    }
}