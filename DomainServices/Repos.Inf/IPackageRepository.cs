using Domain;

namespace DomainServices.Repos.Inf;

public interface IPackageRepository
{
    public Package GetPackageById(int id);
    public IEnumerable<Package> GetPackages();
    public List<Package> GetNonReservedPackages();
    public IEnumerable<Package> GetNonReservedPackagesFiltered(Category? category, string? location);
    public List<Package> GetNonReservedPackagesPerCafeteria(int id);
    public List<Package> GetPackagesByStudent(int StudentId);
    public void CreatePackage(Package package);
    public void UpdatePackage(Package package);
    public void ReservePackageForStudent(Package package, Student student);
    public void RemovePackage(int id);
}