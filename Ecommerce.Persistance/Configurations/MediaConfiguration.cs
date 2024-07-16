using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ecommerce.Domain.Product;

namespace Ecommerce.Persistence.Configurations;

public class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder
            .HasKey(m => m.MediaId);
        builder
            .HasOne(m => m.Color)
            .WithMany(m => m.Media)
            .HasForeignKey(m => m.ColorId);

        // Data for Media
        //var medias = new List<Media>()
        //{
        //    new Media()
        //    {
        //        MediaId = 11,
        //        Priority = 1,
        //        Type = MediaType.Image,
        //        Url = "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32396/49845_1_thumb.png",
        //        ColorId = 62,
        //    },
        //    new Media()
        //    {
        //        MediaId = 12,
        //        Priority = 2,
        //        Type = MediaType.Image,
        //        Url = "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32398/49845_2_thumb.png",
        //        ColorId = 62,
        //    },
        //    new Media()
        //    {
        //        MediaId = 13,
        //        Priority = 3,
        //        Type = MediaType.Image,
        //        Url = "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32400/49845_3_thumb.png",
        //        ColorId = 62,
        //    },
        //    new Media()
        //    {
        //        MediaId = 14,
        //        Priority = 4,
        //        Type = MediaType.Image,
        //        Url = "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32402/49845_4_thumb.png",
        //        ColorId = 62,
        //    },
        //    new Media()
        //    {
        //        MediaId = 15,
        //        Priority = 5,
        //        Type = MediaType.Image,
        //        Url = "https://s3-eu-central-1.amazonaws.com/gpc.prod.storage/uploads/body_shop/product_media_url/image/32404/49845_5_thumb.png",
        //        ColorId = 62,
        //    }
        //};

        // Seed colors to database
        //builder.HasData(medias);
    }
}
