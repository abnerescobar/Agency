using Domain.Customers;
using Domain.Reservation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Persistence.Configuration
{
    public interface IReserveConfiguration
    {
        void Configure(EntityTypeBuilder<Reserve> builder);
       // void Configure(EntityTypeBuilder<Reserve> builder);
    }
}