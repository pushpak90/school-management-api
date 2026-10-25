using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.Models;

public class Student
{
    public int Id {get; set;}
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
    [MaxLength(15)]
    public string ParentPhone {get; set;} = string.Empty;
    public bool IsActive{get; set;} = true;
    public DateTime CreateAt{get; set;} = DateTime.UtcNow;
    public int ClassId{get; set;}
    public SchoolClass? Class{get; set;}
}
