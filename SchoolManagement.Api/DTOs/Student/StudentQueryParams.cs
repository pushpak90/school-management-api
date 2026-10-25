using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Api.DTOs.Student;

public class StudentQueryParams
{
    public string? Search{get; set;}
    public int? ClassId{get; set;}
    [Range(1, int.MaxValue)]
    public int PageNumber{get; set;} = 1;
    [Range(1, 100)]
    public int PageSize{get; set;} = 10;
}
