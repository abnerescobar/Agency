using Domain.Customers;
using Domain.Reservation;
using Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class ReserveRepository : IReserveRepository
    {
        private readonly ApplicationDbContext _context;

        public ReserveRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Reserve reserve)
        {
            foreach (var lineDestination in reserve.LineDestine)
            {
                var newLineDestination = new LineDestination();
                newLineDestination.Id = new LineDestinationId(Guid.NewGuid());
                // Asignar otros valores a las propiedades de newLineDestination si es necesario

                _context.Add(newLineDestination);
            }

            _context.Add(reserve);
        }

        public async Task<Reserve?> GetByIdWithLineAsync(ReserveId id, LineDestinationId lineDestinationId)
        {
            return await _context.Reserves
                .Include(o => o.LineDestine)
                .SingleOrDefaultAsync(o => o.Id == id && o.LineDestine.Any(li => li.Id == lineDestinationId));
        }

        public bool HasOneLineItem(Reserve reserve)
        {
            return _context.LineDestinations.Count(li => li.ReserveId == reserve.Id) == 1;
        }

        public void Update(Reserve reserve)
        {
            _context.Reserves.Update(reserve);
        }

        public void Delete(Reserve reserve)
        {
            _context.Reserves.Remove(reserve);
        }

        public async Task<bool> ExistsAsync(ReserveId id)
        {
            return await _context.Reserves.AnyAsync(r => r.Id == id);
        }

        public async Task<Reserve?> GetByIdAsync(ReserveId id)
        {
            return await _context.Reserves.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Reserve>> GetAll()
        {
            return await _context.Reserves.ToListAsync();
        }
    }
}
