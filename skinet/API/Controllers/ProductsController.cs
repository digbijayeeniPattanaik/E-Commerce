using Core.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var product = await _productRepository.GetProductsAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product != null)
                return Ok(product);
            else
                return NotFound("Product not found");
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrand = await _productRepository.GetProductBrandsAsync();
            if (productBrand != null)
                return Ok(productBrand);
            else
                return NotFound("ProductBrand not found");
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productType = await _productRepository.GetProductTypesAsync();
            if (productType != null)
                return Ok(productType);
            else
                return NotFound("ProductType not found");
        }
    }
}