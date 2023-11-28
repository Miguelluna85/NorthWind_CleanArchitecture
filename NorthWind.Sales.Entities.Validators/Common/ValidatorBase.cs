namespace NorthWind.Sales.Entities.Validators.Common;

internal abstract class ValidatorBase<T> : AbstractValidator<T>
    , IModelValidator<T>
{
    public IEnumerable<ValidationError> Errors { get; private set; }

    async Task<bool> IModelValidator<T>.Validate(T model)
    {
        var Result = await ValidateAsync(model);

        if (!Result.IsValid)
        {
            Errors = Result.Errors.Select(
                e => new ValidationError(e.PropertyName, e.ErrorMessage));
        }

        return Result.IsValid;
    }
}
