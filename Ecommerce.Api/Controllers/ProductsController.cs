using Ecommerce.Application.Features.Product.Commands.CreateProduct;
using Ecommerce.Application.Features.Product.Commands.DeleteProduct;
using Ecommerce.Application.Features.Product.Queries.GetAllProducts;
using Ecommerce.Application.Features.Product.Queries.Shared;
using Ecommerce.Domain.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpGet("[action]")]
        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("[action]/{productId}")]
        public async Task<ProductDto> GetProduct(int productId)
        {
            var products = await _mediator.Send(new GetProductQuery(productId));
            return products;
        }

        // POST api/<ProductsController>
        [HttpPost("[action]")]
        public async Task<CreatedAtActionResult> AddProduct(CreateProductRequest createProductRequest)
        {
            var entityProductId = await _mediator.Send(createProductRequest);
            return CreatedAtAction(nameof(GetProduct), new { productId = entityProductId }, createProductRequest);
        }

        [HttpPost("[action]")]
        public async Task AddProducts([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("[action]/{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var command = new DeleteProductRequest(productId);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
