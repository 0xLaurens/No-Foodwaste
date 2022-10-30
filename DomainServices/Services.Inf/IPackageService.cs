using Domain;

namespace DomainServices.Services.Inf;

public interface IPackageService
{
    public bool PackageDateNotTooFarInTheFutureOrPast(Package package);
    public bool PackageHasCorrectStartAndEnd(Package package);
    public bool PackageHasCorrectDate(Package package);
    
    public bool CanPackageBeReservedByStudent(Package package, Student student);
    public bool StudentOldEnoughForPackage(Package package, Student student);
    public bool StudentCanOrderPackageOnDate(Package package, Student student);
}