using Domain;
using DomainServices.Repos.Inf;

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
        return _context.Packages!.SingleOrDefault(p => p.PackageId == id)!;
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
}