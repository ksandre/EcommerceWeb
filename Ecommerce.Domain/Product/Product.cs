using Ecommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Product;

public class Product : BaseEntity
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string SubCategorySlug { get; set; }
    public string CategorySlug { get; set; }
    public string Description { get; set; }

    public virtual Price? Price { get; set; }
    public virtual List<Size>? Size { get; set; }
}
