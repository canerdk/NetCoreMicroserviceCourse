using Catalog.API.Dtos;
using Catalog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _categoryService.GetByIdAsync(id);

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var response = await _categoryService.CreateAsync(categoryDto);

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }
    }
}
