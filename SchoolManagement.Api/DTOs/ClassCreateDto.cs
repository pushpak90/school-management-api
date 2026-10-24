using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.DTOs;

public class ClassCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Name{get; set;} = string.Empty;
    [Required]
    [MaxLength(10)]
    public string Section {get; set; } = string.Empty;
    [Required]
    [MaxLength(20)]
    public string AcademicYear{get; set;} = string.Empty;
}
