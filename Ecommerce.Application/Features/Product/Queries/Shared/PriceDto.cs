namespace Ecommerce.Application.Features.Product.Queries.Shared;

public class PriceDto
{
    public int PriceId { get; set; }
    public int MaxQuantity { get; set; }
    public decimal InitialPrice { get; set; }
    public decimal DiscountPrice { get; set; }
}
