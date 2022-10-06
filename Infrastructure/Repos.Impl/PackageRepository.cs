using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface PackageRepository : IPackageRepository
{
    public Package GetPackageById(int id);
    public List<Package> GetPackages();
    public List<Package> GetNonReservedPackages();
    public List<Package> GetPackagesByStudent(int StudentId);
}