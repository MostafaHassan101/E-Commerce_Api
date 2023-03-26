using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    public class BrandController : ControllerBase
    {

        private readonly IBrandRepository _iBrandRepository;

        public BrandController(IBrandRepository iBrandRepository)
        {
            _iBrandRepository = iBrandRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Filter(string? name)
        {
            var brands = await _iBrandRepository.FilterByAsync(name);

            return Ok(brands);
        }

    }
}
