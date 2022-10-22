using Domain;

namespace DomainServices.Services.Inf;

public interface IPackageService
{
    public bool CanPackageBeAltered(Package package);
    public bool PackagesHasProductThatContainsAlcohol(Package package);
    public bool CanPackageBeReservedByStudent(Package package, Student student);
    public bool StudentOldEnoughForPackage(Package package, Student student);
    public bool PackageHasCorrectDate(Package package);
    public bool PackageDateNotTooFarInTheFutureOrPast(Package package);

    public bool PackageHasCorrectStartAndEnd(Package package);
    public bool StudentCanOrderPackageOnDate(Package package, Student student);
}