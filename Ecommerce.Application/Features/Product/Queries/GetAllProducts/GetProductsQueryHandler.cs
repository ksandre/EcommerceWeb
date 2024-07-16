using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Features.Currency.Queries.GetAllProducts;
using MediatR;

namespace Ecommerce.Application.Features.Product.Queries.GetAllProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<Ecommerce.Domain.Product.Product>>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductsQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<List<Ecommerce.Domain.Product.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetProductsWithDetails();

        return products;
    }
}
