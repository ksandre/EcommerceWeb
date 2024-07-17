using MediatR;
using Ecommerce.Domain.Product;

namespace Ecommerce.Application.Features.Currency.Queries.GetAllProducts;

public record GetProductsQuery : IRequest<List<ProductDto>>;
