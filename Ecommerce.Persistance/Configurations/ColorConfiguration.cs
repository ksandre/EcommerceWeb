using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Product;
using System.Reflection.Emit;

namespace Ecommerce.Persistence.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.HasKey(c => c.ColorId);
        builder
            .HasOne(s => s.Price)
            .WithOne(s => s.Color)
            .HasForeignKey<Price>(s => s.PriceId);
        builder
            .HasOne(m => m.Size)
            .WithMany(m => m.Colors)
            .HasForeignKey(m => m.SizeId)
            .OnDelete(DeleteBehavior.NoAction);

        // Data for Colors
        //var colors = new List<Color>()
        //{
        //    new Color()
        //    {
        //        ColorId = 62,
        //        Name = "Cherry",
        //        Hex= "#ff0000",
        //        SizeId = 1,
        //    }
        //};

        // Seed colors to database
        //builder.HasData(colors);
    }
}
