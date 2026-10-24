using System;

namespace SchoolManagement.Api.DTOs;

public class ClassResponseDto
{
    public int Id {get; set;}
    public string Name{get; set;} = string.Empty;
    public string Section {get; set;} = string.Empty;
    public string AcademicYear{get; set;} = string.Empty;
}
