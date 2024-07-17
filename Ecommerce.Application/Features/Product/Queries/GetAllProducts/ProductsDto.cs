using Ecommerce.Domain.Product;

namespace Ecommerce.Application.Features.Currency.Queries.GetAllProducts;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string SubCategorySlug { get; set; }
    public string CategorySlug { get; set; }
    public string Description { get; set; }
    public PriceDto? Price { get; set; }
    public List<SizeDto>? Size { get; set; }
}
