using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CategoryCreateDto categoryDto)
        {
            await _service.CreateAsync(categoryDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] CategoryUpdateDto dto)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(id, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.DeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("ReverseSoftDelete/{id}")]
        public async Task<IActionResult> ReverseSoftDeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.ReverseSoftDelete(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
