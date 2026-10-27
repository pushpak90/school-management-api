using System;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Api.Data;
using SchoolManagement.Api.Models;

namespace SchoolManagement.Api.Repositories.Impl;

public class ClassRepository(AppDbContext _context) : IClassRepository
{
    public async Task<SchoolClass> AddAsync(SchoolClass schoolClass)
    {
        _context.Classes.Add(schoolClass);
        await _context.SaveChangesAsync();
        return schoolClass;
    }

    public async Task DeleteAsync(SchoolClass schoolClass)
    {
        _context.Classes.Remove(schoolClass);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string name, string section, string academicYear, int? excludeId = null)
    {
        return await _context.Classes.AnyAsync( c =>
            c.Name == name &&
            c.Section == section &&
            c.AcademicYear == academicYear &&
            (excludeId == null || c.Id != excludeId)
        );
    }

    public async Task<List<SchoolClass>> GetAllAsync()
    {
        return await _context.Classes.AsNoTracking().ToListAsync();
    }

    public async Task<SchoolClass?> GetByIdAsync(int id)
    {
        return await _context.Classes.FindAsync(id);
    }

    public async Task UpdateAsync(SchoolClass schoolClass)
    {
        _context.Classes.Update(schoolClass);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasStudentsAsync(int classId)
    {
        return await _context.Students.AnyAsync(s => s.ClassId == classId);
    }

    public async Task<bool> HasStudentAsync(int classId)
    {
        return await _context.Students.AnyAsync(s => s.ClassId == classId);
    }
}
