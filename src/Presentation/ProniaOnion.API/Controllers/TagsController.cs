﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Tag;

namespace ProniaOnion.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;
        public TagsController(ITagService service)
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
        public async Task<IActionResult> Create([FromForm] TagCreateDto tagDto)
        {
            await _service.CreateAsync(tagDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut()]
        public async Task<IActionResult> Update([FromForm] TagUpdateDto tagDto)
        {
            if (tagDto.Id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(tagDto);
            return NoContent();
        }
        [HttpDelete]
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
            await _service.ReverseSoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}