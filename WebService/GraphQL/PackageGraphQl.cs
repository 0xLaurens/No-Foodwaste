using Domain;
using DomainServices.Repos.Inf;

namespace WebService.GraphQL;

public class PackageGraphQl
{
    public IQueryable<Package> GetPackages([Service] IPackageRepository packageRepository)
    {
        return packageRepository.GetPackages();
    }
}