using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Product;

namespace Ecommerce.Persistence.Configurations;

public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder
            .HasKey(p => p.PriceId);
        builder
            .Property(p => p.InitialPrice)
            .HasPrecision(18, 4);
        builder
            .Property(p => p.DiscountPrice)
            .HasPrecision(18, 4);

        builder
            .HasOne(p => p.Product)
            .WithOne(p => p.Price)
            .HasForeignKey<Price>(c => c.ProductId);
        builder
            .HasOne(p => p.Color)
            .WithOne(p => p.Price)
            .HasForeignKey<Price>(c => c.ColorId);
        builder
            .HasOne(p => p.Size)
            .WithOne(p => p.Price)
            .HasForeignKey<Price>(c => c.SizeId); // Has Forign Key Inside Price

        // Data for Colors
        var prices = new List<Price>()
        {
            new Price()
            {
                PriceId = 7,
                MaxQuantity = 2,
                InitialPrice = 12.25M,
                DiscountPrice = 8.75M,
                ProductId = 260,
                SizeId = 1,
                ColorId = 13,
            },
            new Price()
            {
                PriceId = 8,
                MaxQuantity = 5,
                InitialPrice = 32.25M,
                DiscountPrice = 7.75M,
                ProductId = 261,
                SizeId = null,
                ColorId = 14,
            }
        };

        // Seed colors to database
        builder.HasData(prices);
    }
}
