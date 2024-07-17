using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Features.Currency.Queries.GetAllProducts;
using Ecommerce.Domain.Product;
using MediatR;

namespace Ecommerce.Application.Features.Product.Queries.GetAllProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductsQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productsRepository.GetProductsWithDetails();

        var result = products
            .Select(p => new ProductDto()
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Slug = p.Slug,
                SubCategorySlug = p.SubCategorySlug,
                CategorySlug = p.CategorySlug,
                Description = p.Description,
                Price = p.Price is not null ? new PriceDto()
                {
                    MaxQuantity = p.Price.MaxQuantity,
                    PriceId = p.Price.PriceId,
                    InitialPrice = p.Price.InitialPrice,
                    DiscountPrice = p.Price.DiscountPrice,
                } : null,
                Size = p.Size is not null ? p.Size
                .Where(size => size.ProductId == p.ProductId)
                .Select(s => new SizeDto()
                {
                    SizeId = s.SizeId,
                    SizeValue = s.SizeValue,
                    SizeUnit = s.SizeUnit,
                    Price = s.Price is not null ? new PriceDto()
                    {
                        MaxQuantity = s.Price.MaxQuantity,
                        PriceId = s.Price.PriceId,
                        InitialPrice = s.Price.InitialPrice,
                        DiscountPrice = s.Price.DiscountPrice,
                    } : null,
                    Colors = s.Colors is not null ? s.Colors
                    .Where(color => color.SizeId == s.SizeId)
                    .Select(c => new ColorDto()
                    {
                        ColorId = c.ColorId,
                        Hex = c.Hex,
                        Name = c.Name,
                        Price = c.Price is not null ? new PriceDto()
                        {
                            MaxQuantity = c.Price.MaxQuantity,
                            PriceId = c.Price.PriceId,
                            InitialPrice = c.Price.InitialPrice,
                            DiscountPrice = c.Price.DiscountPrice,
                        } : null,
                        Media = c.Media is not null ? c.Media
                        .Where(media => media.ColorId == c.ColorId)
                        .Select(m => new MediaDto()
                        {
                            MediaId = m.MediaId,
                            Priority = m.Priority,
                            Type = (Currency.Queries.GetAllProducts.MediaType)m.Type,
                            Url = m.Url,
                        }).ToList() : null
                    }).ToList() : null,
                }).ToList() : null
            }).ToList();

        return result;
    }
}
