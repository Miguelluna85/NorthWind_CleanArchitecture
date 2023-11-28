﻿namespace NorthWind.Sales.Backend.BusinessObjects.Exceptions;
public class ValidationException : Exception
{
    public ValidationException()
    {
    }

    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }


    public IEnumerable<ValidationError> Errors { get; set; }

    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;

    }

}
