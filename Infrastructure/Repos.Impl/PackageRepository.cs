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
        return _context.Packages.SingleOrDefault(p => p.PackageId == id);
    }

    public List<Package> GetPackages()
    {
        return _context.Packages.ToList();
    }

    public List<Package> GetNonReservedPackages()
    {
        return _context.Packages.Where(p => p.ReservedByStudentId == null).ToList();
    }

    public List<Package> GetPackagesByStudent(int StudentId)
    {
        return _context.Packages.Where(p => p.ReservedByStudentId == StudentId).ToList();
    }
}