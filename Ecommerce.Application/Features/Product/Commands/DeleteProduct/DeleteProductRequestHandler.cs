using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Product.Commands.DeleteProduct;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, Unit>
{
    private readonly IProductsRepository _productsRepository;
    public DeleteProductRequestHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }
    public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        //var product = await _productsRepository.GetByIdAsync(request.ProductId);
        var product = await _productsRepository.GetProductById(request.ProductId);
        if (product == null)
            throw new NotFoundException(nameof(DeleteProductRequest), request.ProductId);

        await _productsRepository.DeleteAsync(product);
        return Unit.Value;
    }
}
