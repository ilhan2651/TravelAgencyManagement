using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.Guide;
using Tam.Application.Interfaces.Services;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.GuideDto;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController(IGuideService guideService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateGuideDto dto)
        {
            var result = await guideService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await guideService.GetAllAsync(page, pageSize);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await guideService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGuideDto dto)
        {
            var result = await guideService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await guideService.SoftDeleteGuideAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var result = await guideService.SearchAsync(term);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }
        [HttpPost("assign-regions/{guideId}")]
        public async Task<IActionResult> AssignRegions(int guideId, [FromBody] AssignRegionsDto dto)
        {
            var result = await guideService.AssignRegionsAsync(guideId, dto.RegionIds);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpDelete("remove-region/{guideId}")]
        public async Task<IActionResult> RemoveRegion(int guideId, [FromQuery] int regionId)
        {
            var result = await guideService.RemoveRegionsAsync(guideId, regionId);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpPost("assign-locations/{guideId}")]
        public async Task<IActionResult> AssignLocations(int guideId, [FromBody] AssignLocationsDto dto)
        {
            var result = await guideService.AssignLocationsAsync(guideId, dto.LocationIds);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpDelete("remove-location/{guideId}")]
        public async Task<IActionResult> RemoveLocation(int guideId, [FromQuery] int locationId)
        {
            var result = await guideService.RemoveLocationAsync(guideId, locationId);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpPost("assign-languages/{guideId}")]
        public async Task<IActionResult> AssignLanguages(int guideId, [FromBody] AssignLanguagesDto dto)
        {
            var result = await guideService.AssignLanguagesAsync(guideId, dto.LanguageIds);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpDelete("remove-language/{guideId}")]
        public async Task<IActionResult> RemoveLanguage(int guideId, [FromQuery] int languageId)
        {
            var result = await guideService.RemoveLanguageAsync(guideId, languageId);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }
    }
}
