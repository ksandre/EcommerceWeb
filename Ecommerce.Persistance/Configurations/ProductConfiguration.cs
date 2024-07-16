using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Product;

namespace Ecommerce.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);

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
                Description = "ეს ტუჩსაცხი გამორჩეულია დამატენიანებელი მოქმედებით და მდგრადობით.",
            },
            new Product()
            {
                ProductId = 261,
                Name = "Swipe It ტუჩის დამატენიანებელი ბალზამი",
                Slug = "swipe-it-moisturising-lip-balm",
                SubCategorySlug = "lips",
                CategorySlug = "makeup",
                Description = "ეს ბალზამი შექმნილია 95%  დამატენიანებელი ინგრედიენტებით, მათ შორის შის კარაქით, განადან.",
            },
        };

        // Seed products to database
        builder.HasData(products);
    }
}
