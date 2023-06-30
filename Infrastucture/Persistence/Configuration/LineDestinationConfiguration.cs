using Domain.Customers;
using Domain.Packages;
using Domain.Reservation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Persistence.Configuration
{
    public class LineDestinationConfiguration : IEntityTypeConfiguration<LineDestination>
    {
        public void Configure(EntityTypeBuilder<LineDestination> builder)
        {
            builder.HasKey(li => li.Id);
            builder.Property(li => li.Id).HasConversion(
                lineDestinationId => lineDestinationId.Value,
                value => new LineDestinationId(value));
            builder.HasOne<Package>()
                   .WithMany()
                   .HasForeignKey(li => li.PackageId)
                   .IsRequired();
            builder.OwnsOne(li => li.Price);
        }
    }
}
