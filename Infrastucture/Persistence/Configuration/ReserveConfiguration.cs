using Domain.Customers;
using Domain.Reservation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastucture.Persistence.Configuration
{
    public class ReserveConfiguration : IEntityTypeConfiguration<Reserve>
    {
        public void Configure(EntityTypeBuilder<Reserve> builder)
        {

            builder.ToTable("Reserves");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasConversion(
                ReserveId => ReserveId.Value,
                value => new ReserveId(value));
            builder.HasOne<Customer>()
                    .WithMany()
                    .HasForeignKey(o => o.CustomerId)
                    .IsRequired();
            builder.HasMany(o => o.LineDestine)
                    .WithOne()
                    .HasForeignKey(li => li.ReserveId);

        }
    }
}
