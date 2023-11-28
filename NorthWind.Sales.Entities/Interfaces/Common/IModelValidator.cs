﻿namespace NorthWind.Sales.Entities.Interfaces.Common;

public interface IModelValidator<T>
{
    Task<bool> Validate(T model);
    IEnumerable<ValidationError> Errors { get; }

}
