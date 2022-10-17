using Domain;

namespace DomainServices.Repos.Inf;

public interface IPackageRepository
{
    public Package GetPackageById(int id);
    public List<Package> GetPackages();
    public List<Package> GetNonReservedPackages();
    public List<Package> GetNonReservedPackagesPerCafeteria(int id);
    public List<Package> GetPackagesByStudent(int StudentId);
    public void CreatePackage(Package package);
    public void UpdatePackage(Package package);
    public void RemovePackage(int id);
}