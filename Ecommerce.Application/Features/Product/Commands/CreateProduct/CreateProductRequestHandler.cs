using Ecommerce.Application.Contracts.Persistence;
using MediatR;
using Ecommerce.Domain;
using Ecommerce.Domain.Product;
using Ecommerce.Application.Features.Product.Queries.Shared;

namespace Ecommerce.Application.Features.Product.Commands.CreateProduct;

public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, Unit>
{
    private readonly IProductsRepository _productsRepository;
    public CreateProductRequestHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<Unit> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        await _productsRepository.CreateAsync(new Domain.Product.Product()
        {
            Name = request.Name,
            Slug = request.Slug,
            SubCategorySlug = request.SubCategorySlug,
            CategorySlug = request.CategorySlug,
            Description = request.Description,
            Price = request.Price is not null ? new Price()
            {
                MaxQuantity = request.Price.MaxQuantity,
                InitialPrice = request.Price.InitialPrice,
                DiscountPrice = request.Price.DiscountPrice,
            } : null,
            Size = request.Size is not null ? request.Size
                .Select(s => new Size()
                {
                    SizeValue = s.SizeValue,
                    SizeUnit = s.SizeUnit,
                    Price = s.Price is not null ? new Price()
                    {
                        MaxQuantity = s.Price.MaxQuantity,
                        InitialPrice = s.Price.InitialPrice,
                        DiscountPrice = s.Price.DiscountPrice,
                    } : null,
                    Colors = s.Colors is not null ? s.Colors
                    .Select(c => new Color()
                    {
                        Hex = c.Hex,
                        Name = c.Name,
                        Price = c.Price is not null ? new Price()
                        {
                            MaxQuantity = c.Price.MaxQuantity,
                            InitialPrice = c.Price.InitialPrice,
                            DiscountPrice = c.Price.DiscountPrice,
                        } : null,
                        Media = c.Media is not null ? c.Media
                        .Select(m => new Media()
                        {
                            Priority = m.Priority,
                            Type = (Domain.Product.MediaType)m.Type,
                            Url = m.Url,
                        }).ToList() : null
                    }).ToList() : null,
                }).ToList() : null
        });

        return Unit.Value;
    }
}
