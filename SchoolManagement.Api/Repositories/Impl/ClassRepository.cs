using System;
using SchoolManagement.Api.Models;

namespace SchoolManagement.Api.Repositories.Impl;

public class ClassRepository : IClassRepository
{
    public Task<SchoolClass> AddAsync(SchoolClass schoolClass)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(SchoolClass schoolClass)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(string name, string section, string academicYear, int? excludeId = null)
    {
        throw new NotImplementedException();
    }

    public Task<List<SchoolClass>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SchoolClass?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(SchoolClass schoolClass)
    {
        throw new NotImplementedException();
    }
}
