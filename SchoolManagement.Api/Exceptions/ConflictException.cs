using System;

namespace SchoolManagement.Api.Exceptions;

public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
        
    }
}
