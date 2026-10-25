using System;
using SchoolManagement.Api.DTOs;

namespace SchoolManagement.Api.Services;

public interface IClassService
{
    Task<List<ClassResponseDto>> GetAllAsync();
    Task<ClassResponseDto> GetByIdAsync(int id);
    Task<ClassResponseDto> CreateAsync(ClassCreateDto dto);
    Task<ClassResponseDto> UpdateAsync(int id, ClassUpdateDto dto);
    Task DeleteAsync(int id);
}
