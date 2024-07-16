using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Product;

namespace Ecommerce.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);
        builder
            .HasOne(s => s.Price)
            .WithOne(s => s.Product)
            .HasForeignKey<Price>(s => s.PriceId);
        // Data for Products
        var products = new List<Product>()
        {
            new Product()
            {
                ProductId = 260,
                Name = "შემავსებელი ტუჩსაცხი",
                Slug = "peptalk-lipstick-bullet-refill",
                SubCategorySlug = "lips",
                CategorySlug = "makeup",
                Description = "ეს ტუჩსაცხი გამორჩეულია დამატენიანებელი მოქმედებით და მდგრადობით."
            },
        };

        // Seed products to database
        builder.HasData(products);
    }
}
