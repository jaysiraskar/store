using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext context;
        public ProductsController(StoreContext _context)
        {
            context = _context;
             
        }

        [HttpGet]
         public async  Task<ActionResult<List<Product>>> GetProducts(){
            var products = await context.Products.ToListAsync();
            return Ok(products);
         }

         [HttpGet("{id}")]
         public async Task<ActionResult<Product>> GetProduct(int id){
            return await context.Products.FindAsync(id);
         }
    }
}