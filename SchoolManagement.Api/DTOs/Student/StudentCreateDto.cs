using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.DTOs.Student;

public class StudentCreateDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName{get; set;} = string.Empty;
    [Required]
    [MaxLength(50)]
    public string LastName{get; set;} = string.Empty;
    [Required]
    [MaxLength(20)]
    public string RollNumber{get; set;} = string.Empty;
    public DateOnly DateOfBirth{get; set;}
    [Required]
    [MaxLength(100)]
    public string ParentName{get; set;} = string.Empty;
    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Parent phone must be 10 digits.")]
    public string ParentPhone{get; set;} = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "ClassId must be valid class id.")]
    public int ClassId{get; set;}
}
