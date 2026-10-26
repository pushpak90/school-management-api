using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Api.DTOs;
using SchoolManagement.Api.DTOs.Student;
using SchoolManagement.Api.Services;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService _studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PagedResult<StudentResponseDto>>> GetAll([FromQuery] StudentQueryParams query)
        {
            var result = await _studentService.GetAllAsync(query);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponseDto>> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> Create(StudentCreateDto dto)
        {
            var created = await _studentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<StudentResponseDto>> Update(int id, StudentUpdateDto dto)
        {
            var updated = await _studentService.UpdateAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
