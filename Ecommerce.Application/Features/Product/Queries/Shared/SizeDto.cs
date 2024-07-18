namespace Ecommerce.Application.Features.Product.Queries.Shared;

public class SizeDto
{
    public int SizeId { get; set; }
    public string SizeValue { get; set; }
    public string SizeUnit { get; set; }

    public PriceDto? Price { get; set; }
    public List<ColorDto>? Colors { get; set; }

}
