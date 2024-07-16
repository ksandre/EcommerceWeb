using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Product;

public class Price
{
    public int PriceId { get; set; }
    public int MaxQuantity { get; set; }
    public decimal InitialPrice { get; set; }
    public decimal DiscountPrice { get; set; }

    public int? ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public int? ColorId { get; set; }
    public virtual Color? Color { get; set; }

    public int? SizeId { get; set; }
    public virtual Size? Size { get; set; }
}
