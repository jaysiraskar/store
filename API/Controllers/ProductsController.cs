using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        [HttpGet]
         public async  Task<ActionResult<List<Product>>> GetProducts()
         {
            var products = await productRepository.GetProductsAsync();
            return Ok(products);
         }

         [HttpGet("{id}")]
         public async Task<ActionResult<Product>> GetProduct(int id)
         {
            return await productRepository.GetProductByIdAsync(id);
         }

         [HttpGet("brands")]
         public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandsAsync()
         {
            return Ok(await productRepository.GetProductBrandsAsync());
         }
         [HttpGet("types")]
         public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypesAsync()
         {
            return Ok(await productRepository.GetProductTypesAsync());
         }
    }


}