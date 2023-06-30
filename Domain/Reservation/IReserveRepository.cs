
namespace Domain.Reservation;
public interface IReserveRepository
{
    /* Task<Reserve?> GetByIdWithLineItemAsync(ReserveId id, LineDestinationId lineDestinationId);
     bool HasOneLineItem(Reserve reserve);
     void Add(Reserve reserve);*/
    Task<List<Reserve>> GetAll();
    Task<Reserve?> GetByIdWithLineAsync(ReserveId id, LineDestinationId lineDestinationId);
    bool HasOneLineItem(Reserve reserve);
    Task<bool> ExistsAsync(ReserveId id);
    void Add(Reserve reserve);
    void Update(Reserve reserve);
    void Delete(Reserve reserve);
}
