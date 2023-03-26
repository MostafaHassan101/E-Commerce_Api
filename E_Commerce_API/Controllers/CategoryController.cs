using Application.Contracts;
using Context;
using E_Commerce_API.Reposatories;
using Microsoft.AspNetCore.Mvc;
using Reposatory;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        //public DContext _context= new DContext();

        //private DContext _Context;
        //private readonly RepoCategory RepoCategory;
        //public CategoryController(DContext context)
        //{
        //    _context = context;

        //    //_Context = context;
        //}



        //private CategoryController(RepoCategory _Category)
        //{
        //    RepoCategory = _Category;
        //}

        //      [HttpGet]
        //      public async Task<IActionResult> GetCategories(string? filter = null)
        //      {
        //	var data = await RepoCategory.FilterByAsync(filter);
        //	return Ok(data);
        //}
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetCategoryByID(int id)
        {
            var categories =await _categoryRepository.GetByIdAsync(id);
            return Ok(categories);
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            return Ok(await _categoryRepository.DeleteAsync(id));
        }


    }
}
