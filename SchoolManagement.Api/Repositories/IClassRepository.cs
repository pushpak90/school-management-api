using System;
using SchoolManagement.Api.Models;

namespace SchoolManagement.Api.Repositories;

public interface IClassRepository
{
    Task<List<SchoolClass>> GetAllAsync();
    Task<SchoolClass?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(string name, string section, string academicYear, int? excludeId = null);
    Task<SchoolClass> AddAsync(SchoolClass schoolClass);
    Task UpdateAsync(SchoolClass schoolClass);
    Task DeleteAsync(SchoolClass schoolClass);
    Task<bool> HasStudentAsync(int classId);
}
