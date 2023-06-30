
using Domain.Packages;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastucture.Persistence.Configuration;

internal class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> builder)
    {

        builder.HasKey(p => p.Id);

        builder.Property(li => li.Id).HasConversion(
            lineDestinationId => lineDestinationId.Value,
            value => new PackageId(value));

        builder.Property(p => p.Sku).HasConversion(
            sku => sku.Value,
            value => Sku.Create(value)!);

        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);

        });
    }

}
