using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolManagement.Api.DTOs;
using SchoolManagement.Api.DTOs.Student;
using SchoolManagement.Api.Exceptions;
using SchoolManagement.Api.Models;
using SchoolManagement.Api.Repositories;

namespace SchoolManagement.Api.Services.Impl;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepo;
    private readonly IClassRepository _classRepo;
    public StudentService(IStudentRepository studentRepository, IClassRepository classRepo)
    {
        _studentRepo = studentRepository;
        _classRepo = classRepo;
    }
    public async Task<StudentResponseDto> CreateAsync(StudentCreateDto dto)
    {
        await ValidateAsync(dto.ClassId, dto.RollNumber, dto.DateOfBirth, null);
        var student = new Student
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            RollNumber = dto.RollNumber,
            DateOfBirth = dto.DateOfBirth,
            ParentName = dto.ParentName,
            ParentPhone = dto.ParentPhone,
            ClassId = dto.ClassId
        };

        var created = await _studentRepo.AddAsync(student);
        var saved = await GetExistingAsync(created.Id);
        return ToResponse(saved);
    }

    public async Task DeleteAsync(int id)
    {
        var student = await GetExistingAsync(id);
        if (await _classRepo.HasStudentAsync(id))
        {
            throw new ConflictException($"This class has students and cannot be deleted");
        }
        await _studentRepo.DeleteAsync(student);
    }

    public async Task<PagedResult<StudentResponseDto>> GetAllAsync(StudentQueryParams query)
    {
        var (items, totalCount) = await _studentRepo.GetPagedAsync(
            query.Search, query.ClassId, query.PageNumber, query.PageSize
        );

        return new PagedResult<StudentResponseDto>
        {
            Items = items.Select(ToResponse).ToList(),
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalCount = totalCount
        };
    }

    public async Task<StudentResponseDto> GetByIdAsync(int id)
    {
        var student = await GetExistingAsync(id);
        return ToResponse(student);
    }

    public async Task<StudentResponseDto> UpdateAsync(int id, StudentUpdateDto dto)
    {
        var student = await GetExistingAsync(id);
        await ValidateAsync(dto.ClassId, dto.RollNumber, dto.DateOfBirth, id);

        student.FirstName = dto.FirstName;
        student.LastName = dto.LastName;
        student.RollNumber = dto.RollNumber;
        student.DateOfBirth = dto.DateOfBirth;
        student.ParentName = dto.ParentName;
        student.ParentPhone = dto.ParentPhone;
        student.ClassId = dto.ClassId;

        await _studentRepo.UpdateAsync(student);
        var saved = await GetExistingAsync(id);
        return ToResponse(saved);
    }

    private async Task ValidateAsync(int classId, string rollNumber, DateOnly dateOfBirth, int? excludeId)
    {
        if(dateOfBirth > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new BadRequestException("Date of birth cannot be in the future");
        }

        var schoolClass = await _classRepo.GetByIdAsync(classId);
        if(schoolClass is null)
        {
            throw new BadRequestException($"Class with id {classId} does not exist.");
        }

        if(await _studentRepo.RollNumberExistsAsync(classId, rollNumber, excludeId))
        {
            throw new ConflictException($"Roll Number {rollNumber} is already used in this class.");
        }
    }

    private async Task<Student> GetExistingAsync(int id)
    {
        var student = await _studentRepo.GetByIdAsync(id);
        if(student is null)
        {
            throw new NotFoundException($"Studnet with id {id} not found.");
        }
        return student;
    }
    private static StudentResponseDto ToResponse(Student s)
    {
        return new StudentResponseDto
        {
          Id = s.Id,
          FirstName = s.FirstName,
          LastName = s.LastName,
          RollNumber = s.RollNumber,
          DateOfBirth = s.DateOfBirth,
          ParentName = s.ParentName,
          ParentPhone = s.ParentPhone,
          ClassId = s.ClassId,
          ClassName = s.Class is null ? string.Empty : $"{s.Class.Name} - {s.Class.Section}"  ,
          IsActive = s.IsActive
        };
    }
}
