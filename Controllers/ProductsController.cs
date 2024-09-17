using Microsoft.AspNetCore.Mvc;
using MuleWebAPIPhatPT19.Business.Services.Interfaces;
using MuleWebAPIPhatPT19.Data.Models.DTOs;

namespace MuleWebAPIPhatpt19.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO)
        {
            await _productService.AddProductAsync(productDTO);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("Product data is null.");
            }

            var result = await _productService.UpdateProductById(productDTO);
            if (!result)
            {
                return NotFound($"Product with ID '{productDTO.ProductCode}' not found.");
            }

            return Ok("Product updated successfully.");
        }

        [HttpGet("{productId}/{unitPrice}")]
        public async Task<IActionResult> GetProductsById(string productId, double unitPrice)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return BadRequest("Product ID is null or empty.");
            }

            var product = await _productService.FindProductById(productId, unitPrice);
            if (product == null)
            {
                return NotFound($"Product with ID '{productId}' not found.");
            }

            return Ok(product);
        }

    }
}
