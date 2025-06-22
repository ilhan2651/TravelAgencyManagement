using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.CategoryDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createDto)
        {
            var result = await categoryService.CreateCategoryAsync(createDto);
            return Ok(result.Message);
        }

        [HttpGet("get-all-categories")]
        public async Task<IActionResult> GetAll()
        {
            var result = await categoryService.GetAllCategories();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await categoryService.GetCategoryByIdAsync(id);
            return result.Success ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto updateDto)
        {
            var result = await categoryService.UpdateCategoryAsync(id, updateDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await categoryService.SoftDeleteCategoryAsync(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
