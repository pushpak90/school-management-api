using System;

namespace SchoolManagement.Api.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message )
    {
        
    }
}
