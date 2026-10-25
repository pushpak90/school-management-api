using System;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Api.Data;
using SchoolManagement.Api.Models;

namespace SchoolManagement.Api.Repositories.Impl;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _appDbContext;

    public StudentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Student> AddAsync(Student student)
    {
        _appDbContext.Students.Add(student);
        await _appDbContext.SaveChangesAsync();
        return student;
    }

    public async Task DeleteAsync(Student student)
    {
        _appDbContext.Students.Remove(student);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _appDbContext.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == id);    
    }

    public async Task<(List<Student> Items, int TotalCount)> GetPagedAsync(string? search, int? classId, int pageNumber, int pageSize)
    {
        var query = _appDbContext.Students.AsNoTracking().Include(s => s.Class).AsQueryable();
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where( s =>
                s.FirstName.Contains(search) || 
                s.LastName.Contains(search) ||
                s.RollNumber.Contains(search)
            );
        }

        if (classId.HasValue)
        {
            query = query.Where(s => s.ClassId == classId.Value);
        }

        var totalCount = await query.CountAsync();

        var item = await query
                    .OrderBy(s => s.FirstName)
                    .ThenBy(s => s.LastName)
                    .ThenBy(s => s.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
        return (item, totalCount);
    }

    public async Task<bool> RollNumberExistsAsync(int classId, string rollNumber, int? excludeId = null)
    {
        return await _appDbContext.Students.AnyAsync( s =>
            s.ClassId == classId &&
            s.RollNumber == rollNumber &&
            (excludeId == null || s.Id != excludeId)
        );
    }

    public async Task UpdateAsync(Student student)
    {
        _appDbContext.Students.Remove(student);
        await _appDbContext.SaveChangesAsync();
    }
}
