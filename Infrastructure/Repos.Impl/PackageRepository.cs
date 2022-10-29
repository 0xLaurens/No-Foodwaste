using Domain;
using DomainServices.Repos.Inf;
using DomainServices.Services.Inf;
using Microsoft.EntityFrameworkCore;

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

    public Package? GetPackageById(int id)
    {
        return GetPackages().SingleOrDefault(p => p.PackageId == id);
    }

    public IQueryable<Package> GetPackages()
    {
        return _context.Packages!
            .Where(p => p.StartTimeSlot > DateTime.Today.Date)
            .Include(p => p.Cafeteria)
            .ThenInclude(cf => cf!.Location)
            .Include(p => p.City)
            .Include(p => p.Products)
            .OrderBy(p => p.EndTimeSlot);
    }

    public IQueryable<Package> GetNonReservedPackages()
    {
        return GetPackages()
            .Where(p => p.StudentId == null);
    }

    public IQueryable<Package> GetNonReservedPackagesFiltered(Category? category, string? location)
    {
        if (category != null && location != null)
            return GetNonReservedPackages()
                .Where(p => p.Cafeteria!.Location!.Name == location && p.Category == category);
        if (location != null)
            return GetNonReservedPackages().Where(p => p.Cafeteria!.Location!.Name == location);
        if (category != null) return GetNonReservedPackages().Where(p => p.Category == category);

        return GetNonReservedPackages();
    }


    public IQueryable<Package> GetNonReservedPackagesPerCafeteria(int id)
    {
        return GetNonReservedPackages()
            .Where(p => p.CafeteriaId == id);
    }

    public IQueryable<Package> GetPackagesByStudent(Student student)
    {
        return GetPackages()
            .Where(p => student != null && p.StudentId == student.StudentId);
    }

    public IQueryable<Package> GetPackagesByStudentFiltered(Student student, string? location, Category? category)
    {
        if (category != null && location != null)
            return GetPackagesByStudent(student)
                .Where(p => p.Cafeteria!.Location!.Name == location && p.Category == category);
        if (location != null)
            return GetPackagesByStudent(student).Where(p => p.Cafeteria!.Location!.Name == location);
        if (category != null) return GetPackagesByStudent(student).Where(p => p.Category == category);

        return GetPackagesByStudent(student);
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
        if (!_packageService.CanPackageBeAltered(entry!))
            throw new InvalidOperationException("Cannot be altered");
        if (!_packageService.PackageHasCorrectDate(package))
            throw new InvalidOperationException("Wrong date");

        // Explicit deletion of all foreign keys
        entry!.Products!.Any(p => entry.Products!.Remove(p));

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

        package.StudentId = student.StudentId;
        _context.SaveChanges();
    }

    public void DeletePackage(int id)
    {
        var entry = GetPackageById(id);
        if (!_packageService.CanPackageBeAltered(entry!))
            throw new InvalidOperationException();
        _context.Packages?.Remove(entry!);
        _context.SaveChanges();
    }

    public void DeletePackage(Package package)
    {
        if (!_packageService.CanPackageBeAltered(package))
            throw new InvalidOperationException();
        _context.Packages?.Remove(package);
        _context.SaveChanges();
    }
}