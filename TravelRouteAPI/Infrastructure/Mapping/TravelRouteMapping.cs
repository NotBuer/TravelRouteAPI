using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

public class TravelRouteMapping : IEntityTypeConfiguration<TravelRoute>
{
    public void Configure(EntityTypeBuilder<TravelRoute> builder)
    {
        builder.ToTable(nameof(TravelRoute))
            .HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Origin)
            .IsRequired();

        builder.Property(x => x.Destination)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .IsRequired();
    }
}