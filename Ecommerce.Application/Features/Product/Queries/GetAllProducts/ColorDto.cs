using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Application.Features.Currency.Queries.GetAllProducts;

public class ColorDto
{
    public int ColorId { get; set; }
    public string Hex { get; set; }
    public string Name { get; set; }
    public PriceDto? Price { get; set; }
    public List<MediaDto>? Media { get; set; }
}
