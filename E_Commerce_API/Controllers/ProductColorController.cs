using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Reposatory;

namespace E_Commerce_API.Controllers
{
    public class ProductColorController : ControllerBase
    {
        private readonly iproductColorRepository _iproductColorRepository;

        public ProductColorController(iproductColorRepository iproductColorRepository)
        {
            _iproductColorRepository = iproductColorRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Filter(string? name)
        {
            var colors = await _iproductColorRepository.FilterByAsync(name);

            return Ok(colors);
        }
    }
}
