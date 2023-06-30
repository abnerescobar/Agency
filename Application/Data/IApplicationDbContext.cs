using Microsoft.EntityFrameworkCore;
using Domain.Customers;
using Domain.Packages;
using Domain.Reservation;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Customer> Customers { get; set; }
    DbSet<Package> Packages { get; set; }
    DbSet<Reserve> Reserves { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
