using System;
using SchoolManagement.Api.Models;

namespace SchoolManagement.Api.Repositories;

public interface IStudentRepository
{
    Task<(List<Student> Items, int TotalCount)> GetPagedAsync(
        string? search, int? classId, int pageNumber, int pageSize);
    Task<Student?> GetByIdAsync(int id);
    Task<bool> RollNumberExistsAsync(int classId, string rollNumber, int? excludeId = null);
    Task<Student> AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(Student student);
}
