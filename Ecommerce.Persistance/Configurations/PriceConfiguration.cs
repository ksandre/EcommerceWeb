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
            .HasForeignKey<Product>(c => c.ProductId);
        builder
            .HasOne(p => p.Color)
            .WithOne(p => p.Price)
            .HasForeignKey<Color>(c => c.ColorId);
        builder
            .HasOne(p => p.Size)
            .WithOne(p => p.Price)
            .HasForeignKey<Size>(c => c.SizeId);

        // Data for Colors
        //var prices = new List<Price>()
        //{
        //    new Price()
        //    {
        //        PriceId = 7,
        //        ProductId = 260,
        //        ColorId = 62,
        //        SizeId = 1,
        //        MaxQuantity = 2,
        //        InitialPrice = 12.25M,
        //        DiscountPrice = 8.75M
        //    }
        //};

        // Seed colors to database
        //builder.HasData(prices);
    }
}
