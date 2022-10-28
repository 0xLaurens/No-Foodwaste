using Domain;
using DomainServices.Repos.Inf;

namespace WebService.GraphQL;

public class PackageGraphQl
{
   private readonly IPackageRepository _packageRepository;
   public PackageGraphQl(IPackageRepository packageRepository)
   {
      _packageRepository = packageRepository;
   }
   public IQueryable<Package> GetPackages()
   {
      return _packageRepository.GetPackages();
   }
}