using Ecommerce.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Currency.Queries.GetAllProducts;

public class ProductsDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string SubCategorySlug { get; set; }
    public string CategorySlug { get; set; }
    public string Description { get; set; }
    public List<Size>? Size { get; set; }
}
