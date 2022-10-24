using Domain;

namespace DomainServices.Repos.Inf;

public interface IPackageRepository
{
    public Package? GetPackageById(int id);
    public IQueryable<Package> GetPackages();
    public IQueryable<Package> GetNonReservedPackages();
    public IQueryable<Package> GetNonReservedPackagesFiltered(Category? category, string? location);
    public IQueryable<Package> GetNonReservedPackagesPerCafeteria(int id);
    public IQueryable<Package>? GetPackagesByStudent(Student student);
    public void CreatePackage(Package package);
    public void UpdatePackage(Package package);
    public void ReservePackageForStudent(Package package, Student student);
    public void RemovePackage(int id);
}