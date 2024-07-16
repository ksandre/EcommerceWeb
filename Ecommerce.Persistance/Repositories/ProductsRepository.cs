using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Domain.Product;
using Ecommerce.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence.Repositories;

public class ProductsRepository : GenericRepository<Product>, IProductsRepository
{
    public ProductsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsWithDetails()
    {
        var products = await _context.Products

                .Include(p => p.Size)
                
                            .ToListAsync();

        return products;
    }
}
