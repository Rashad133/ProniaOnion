using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.DTOs.Colors;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _service;
        public ColorsController(IColorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ColorCreateDto colorDto)
        {
            await _service.CreateAsync(colorDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromForm] ColorUpdateDto colorDto)
        //{
        //    await _service.UpdateAsync(id, colorDto);
        //    return NoContent();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] ColorUpdateDto colorDto)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            await _service.UpdateAsync( colorDto);

            return NoContent();
        }
    }
}
