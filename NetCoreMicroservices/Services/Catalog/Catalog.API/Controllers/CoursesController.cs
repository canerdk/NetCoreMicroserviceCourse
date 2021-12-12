using Catalog.API.Dtos;
using Catalog.API.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }

        [HttpGet("getallbyuserid")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _courseService.GetAllByUserIdAsync(userId);

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            var response = await _courseService.CreateAsync(courseCreateDto);

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var response = await _courseService.UpdateAsync(courseUpdateDto);

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteAsync(id);

            if (response.StatusCode == 404)
            {
                return NotFound(response.Errors);
            }
            return Ok(response);
        }
    }
}
