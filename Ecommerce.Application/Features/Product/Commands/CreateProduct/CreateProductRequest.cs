using MediatR;
using Ecommerce.Domain.Product;
using Ecommerce.Application.Features.Product.Queries.Shared;
using Ecommerce.Application.Features.Product.Commands.CreateSize;
using Ecommerce.Application.Features.Product.Commands.CreatePrice;

namespace Ecommerce.Application.Features.Product.Commands.CreateProduct;

public class CreateProductRequest : IRequest<int> {
    public string Name { get; set; }
    public string Slug { get; set; }
    public string SubCategorySlug { get; set; }
    public string CategorySlug { get; set; }
    public string Description { get; set; }
    public CreatePriceRequest? Price { get; set; }
    public List<CreateSizeRequest>? Size { get; set; }
}
