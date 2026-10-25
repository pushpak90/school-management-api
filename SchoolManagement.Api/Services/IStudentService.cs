using System;
using SchoolManagement.Api.DTOs;
using SchoolManagement.Api.DTOs.Student;

namespace SchoolManagement.Api.Services;

public interface IStudentService
{
    Task<PagedResult<StudentResponseDto>> GetAllAsync(StudentQueryParams query);
    Task<StudentResponseDto> GetByIdAsync(int id);
    Task<StudentResponseDto> CreateAsync(StudentCreateDto dto);
    Task<StudentResponseDto> UpdateAsync(int id, StudentUpdateDto dto);
    Task DeleteAsync(int id);
}
