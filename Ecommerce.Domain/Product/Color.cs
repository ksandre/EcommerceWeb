using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Product;

public class Color
{
    public int ColorId { get; set; }
    public string Hex { get; set; }
    public string Name { get; set; }
    public virtual Price? Price { get; set; }
    public virtual List<Media>? Media { get; set; }

    public int? SizeId { get; set; }
    public virtual Size? Size { get; set; }
}
