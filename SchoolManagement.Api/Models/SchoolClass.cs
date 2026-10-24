using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.Models;

public class SchoolClass
{
    [Key]
    public int Id {get; set;}
    [Required]
    [MaxLength(50)]
    public string? Name {get; set;}
    [Required]
    [MaxLength(10)]
    public string? Section{get; set;}
    [Required]
    [MaxLength(20)]
    public string? AcademicYear{get; set;}
}
