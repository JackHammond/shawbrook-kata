using Microsoft.AspNetCore.Mvc;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Controllers
{
    [ApiController]
    [Route("api/v1/categories/")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("products", Name = "GetProducts")]
        public async Task<ActionResult<List<IProduct>>> GetProducts()
        {
            // Make call to service
            List<IProduct> products = await _productService.GetProducts();
            return Ok(products);
        }
    }
}