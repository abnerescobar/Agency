namespace Domain.Packages;
public interface IPackageRepository
{
    Task<List<Package>> GetAll();
    Task<Package?> GetByIdAsync(PackageId id);
    Task<bool> ExistsAsync(PackageId id);
    void Add(Package package);
    void Update(Package package);
    void Delete(Package package);
}
