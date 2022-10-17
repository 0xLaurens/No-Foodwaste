using Domain;

namespace DomainServices.Services.Inf;

public interface IPackageService
{
    public bool PackagesHasProductThatContainsAlcohol(Package package);
    public bool CanPackageBeReservedByStudent(Package package, Student student);
    public bool PackageHasCorrectDate(Package package);
}