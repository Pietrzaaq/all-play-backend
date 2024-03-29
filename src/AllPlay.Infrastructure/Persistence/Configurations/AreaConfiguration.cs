﻿using AllPlay.Domain.Common;
using AllPlay.Domain.Entities;
using AllPlay.Domain.ValueObjects.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllPlay.Infrastructure.Persistence.Configurations;

public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasMany(area => area.SportEvents)
            .WithOne()
            .HasForeignKey(x => x.AreaId);
        
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new Id(x));

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(TextLengths.Field);

        builder.Property(x => x.StreetAddress)
            .IsRequired()
            .HasMaxLength(TextLengths.Field);
        
        builder.Property(x => x.CountryRegion)
            .IsRequired()
            .HasMaxLength(TextLengths.Field);
        
        builder.Property(x => x.CountryIso)
            .IsRequired()
            .HasMaxLength(TextLengths.CountryCode);
        
        builder.Property(x => x.PostalCode)
            .IsRequired()
            .HasMaxLength(TextLengths.PostalCode);
        
        builder.Property(x => x.FormattedAddress)
            .IsRequired()
            .HasMaxLength(TextLengths.ShortText);

        builder.Property(x => x.Polygon)
            .IsRequired();
        
        builder.Property(x => x.Point)
            .IsRequired();
        
        builder.Property(x => x.OpenStreetMapId);
        builder.Property(x => x.OpenStreetMapName);
        builder.Property(x => x.IsOutdoorArea);
        builder.Property(x => x.Leisure);
        builder.Property(x => x.Sport);
        builder.Property(x => x.HasMultipleSports);
        builder.Property(x => x.Surface);
        builder.Property(x => x.Lit);
        builder.Property(x => x.Access);
        builder.Property(x => x.Barrier);
        
        builder.Property(x => x.PhoneNumber)
            .HasConversion(x => x.Value, x => new PhoneNumber(x))
            .HasMaxLength(TextLengths.PhoneNumber);
        
        builder.OwnsOne(x => x.Coordinates)
            .Property(x => x.Latitude)
            .HasColumnName("Latitude");
        
        builder.OwnsOne(x => x.Coordinates)
            .Property(x => x.Longitude)
            .HasColumnName("Longitude");
    }    
}