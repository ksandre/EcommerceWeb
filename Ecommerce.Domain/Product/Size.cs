using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Product;

public class Size
{
    public int SizeId { get; set; }
    public string SizeValue { get; set; }
    public string SizeUnit { get; set; }

    public virtual Price? Price { get; set; }
    public virtual List<Color>? Colors { get; set; }

    public int? ProductId { get; set; }
    public virtual Product? Product { get; set; }

}
