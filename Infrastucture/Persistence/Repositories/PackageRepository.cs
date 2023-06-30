using Domain.Packages;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly ApplicationDbContext _context;

        public PackageRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Package package) => _context.Packages.Add(package);
        public void Delete(Package package) => _context.Packages.Remove(package);
        public void Update(Package package) => _context.Packages.Update(package);
        public async Task<bool> ExistsAsync(PackageId id) => await _context.Packages.AnyAsync(p => p.Id == id);
        public async Task<Package?> GetByIdAsync(PackageId id) => await _context.Packages.SingleOrDefaultAsync(p => p.Id == id);
        public async Task<List<Package>> GetAll() => await _context.Packages.ToListAsync();
    }
}
