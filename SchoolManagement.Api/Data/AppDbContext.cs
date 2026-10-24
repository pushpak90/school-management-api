using System;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Api.Models;

namespace SchoolManagement.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SchoolClass>()
            .HasIndex(c => new {c.Name, c.Section, c.AcademicYear})
            .IsUnique();
    }

    public DbSet<SchoolClass> Classes {get; set;}
}
