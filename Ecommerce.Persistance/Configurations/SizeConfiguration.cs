using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Product;

namespace Ecommerce.Persistence.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.HasKey(s => s.SizeId);
        //builder
        //    .HasOne(s => s.Price)
        //    .WithOne(s => s.Size)
        //    .HasForeignKey<Price>(s => s.PriceId);
        builder
            .HasOne(m => m.Product)
            .WithMany(m => m.Size)
            .HasForeignKey(m => m.ProductId)
            .OnDelete(DeleteBehavior.NoAction);


        // Data for Sizes
        var sizes = new List<Size>()
        {
            new Size()
            {
                SizeId = 1,
                SizeUnit = "გრ",
                SizeValue = "4.0",
                ProductId = 260
            },
            new Size()
            {
                SizeId = 2,
                SizeUnit = "გრ",
                SizeValue = "15.0",
                ProductId = 261
            },
        };

        // Seed sizes to database
        builder.HasData(sizes);
    }
}
