using Ecommerce.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts.Persistence;

public interface IProductsRepository: IGenericRepository<Product>
{
    Task<List<Product>> GetProductsWithDetails();
}