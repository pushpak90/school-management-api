using System;

namespace SchoolManagement.Api.DTOs.Student;

public class StudentResponseDto
{
    public int Id{get; set;}
    public string FirstName{get; set;} = string.Empty;
    public string LastName{get; set;} = string.Empty;
    public string RollNumber {get; set;} = string.Empty;
    public DateOnly DateOfBirth {get; set;}
    public string ParentName{get; set;} = string.Empty;
    public string ParentPhone {get; set;} = string.Empty;
    public int ClassId{get; set;}
    public string ClassName{get; set;} = string.Empty;
    public bool IsActive{get; set;}
}
