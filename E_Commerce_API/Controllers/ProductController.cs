using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Reposatory;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Filter(string? name, string? Category, int? fromPrice, int? toPrice, string? brand, long? colorId)
        {
            var products = await _productRepository.FilterByAsync(name, Category, fromPrice, toPrice, brand, colorId);

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(long id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return Ok(product);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            return Ok(await _productRepository.DeleteAsync(id));
        }
            //[HttpPost]
            //public async Task<IActionResult> CreateProductAsync(string name, string namear, string description, string desacriptionar, decimal price, string? size, string imgurl, byte? rate, long CategoryId, int brandid)
            //{
            //    var product = new Product()
            //    {
            //        Name = name,
            //        NameAr = namear,
            //        DescriptionAr = description,
            //        Description = description,
            //        Price = price,
            //        Sizes = size,
            //        ImagePath = imgurl,
            //        Rate = rate,
            //    };


            //}

        } 
}
