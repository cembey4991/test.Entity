using Microsoft.AspNetCore.Mvc;
using test.Business.Dtos;
using test.Business.Interface;

namespace test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            var addCategory = await _categoryService.InsertOne(category);
            return Ok(addCategory);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var result = await _categoryService.DeleteById(id);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto category)
        {
            var result = _categoryService.ReplaceOne(category);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var result = _categoryService.FindById(id);
            return Ok(result);

        }
        [HttpGet]

        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(_categoryService.GetAll());
        }



        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryByIdToProducts(string id)
        {
            return Ok(await _categoryService.GetCategoryByIdToProducts(id));
        }

    }
}
