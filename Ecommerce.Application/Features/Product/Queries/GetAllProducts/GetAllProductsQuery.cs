using MediatR;
using Ecommerce.Domain.Product;
using Ecommerce.Application.Features.Product.Queries.Shared;

namespace Ecommerce.Application.Features.Product.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<List<ProductDto>>;
