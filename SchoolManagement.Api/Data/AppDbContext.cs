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
        
        modelBuilder.Entity<Student>()
            .HasIndex(s => new {s.ClassId, s.RollNumber})
            .IsUnique();

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Class)
            .WithMany()
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<SchoolClass> Classes {get; set;}
    public DbSet<Student> Students {get; set;}
}
