using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.Models;

public class SchoolClass
{
    [Key]
    public int Id {get; set;}
    public string? Name {get; set;}
    public string? Section{get; set;}
    public string? AcademicYear{get; set;}
}
