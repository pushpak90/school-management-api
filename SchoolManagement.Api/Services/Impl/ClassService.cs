using System;
using SchoolManagement.Api.DTOs;
using SchoolManagement.Api.Exceptions;
using SchoolManagement.Api.Models;
using SchoolManagement.Api.Repositories;

namespace SchoolManagement.Api.Services.Impl;

public class ClassService(IClassRepository _classRepo) : IClassService
{
    public async Task<ClassResponseDto> CreateAsync(ClassCreateDto dto)
    {
        if(await _classRepo.ExistsAsync(dto.Name, dto.Section, dto.AcademicYear))
        {
            throw new  ConflictException("This class already exsists.");
        }
        var schoolClass = new SchoolClass
        {
          Name = dto.Name,
          Section = dto.Section,
          AcademicYear = dto.AcademicYear  
        };

        var created = await _classRepo.AddAsync(schoolClass);
        return ToResponse(created);
    }

    public async Task DeleteAsync(int id)
    {
        var schoolClass = await GetExistingAsync(id);
        await _classRepo.DeleteAsync(schoolClass);
    }

    public async Task<List<ClassResponseDto>> GetAllAsync()
    {
        var classes = await _classRepo.GetAllAsync();
        return classes.Select(ToResponse).ToList();
    }

    public async Task<ClassResponseDto> GetByIdAsync(int id)
    {
        var schoolClass = await GetExistingAsync(id);
        return ToResponse(schoolClass);
    }

    public async Task<ClassResponseDto> UpdateAsync(int id, ClassUpdateDto dto)
    {
        var schoolClass = await GetExistingAsync(id);
        if(await _classRepo.ExistsAsync(dto.Name, dto.Section, dto.AcademicYear))
        {
            throw new ConflictException("Another class with the same details already exists.");
        }

        schoolClass.Name = dto.Name;
        schoolClass.Section = dto.Section;
        schoolClass.AcademicYear = dto.AcademicYear;

        await _classRepo.UpdateAsync(schoolClass);
        return ToResponse(schoolClass);
    }

    private static ClassResponseDto ToResponse(SchoolClass c)
    {
        return new ClassResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            Section = c.Section,
            AcademicYear = c.AcademicYear
        };
    }

    private async Task<SchoolClass> GetExistingAsync(int id)
    {
        var schoolClass = await _classRepo.GetByIdAsync(id);
        if(schoolClass is null)
        {
            throw new NotFoundException($"Class with id {id} was not found");
        }
        return schoolClass;
    }
}
