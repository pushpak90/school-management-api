using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.DTOs;
using SchoolManagement.Api.Models;
using SchoolManagement.Api.Services;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController(IClassService _classService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ClassResponseDto>>> GetAll()
        {
            var classes = await _classService.GetAllAsync();
            return Ok(classes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClassResponseDto>> GetById(int id)
        {
            var schoolClass = await _classService.GetByIdAsync(id);
            return Ok(schoolClass);
        }

        [HttpPost]
        public async Task<ActionResult<ClassResponseDto>> Create(ClassCreateDto dto)
        {
            var created = await _classService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ClassResponseDto>> Update(int id, ClassUpdateDto dto)
        {
            var updated = await _classService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _classService.DeleteAsync(id);
            return NoContent();
        }
    }
}
