namespace NorthWind.Sales.Entities.Validators.CreateOrder;

internal class CreateOrderDetailDtoValidator :
    ValidatorBase<CreateOrderDetailDto>
{

    public CreateOrderDetailDtoValidator()
    {
        RuleFor(d => d.ProductId)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.ProductIdGreatherThanZero);

        RuleFor<int>(d => d.Quantity)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.QuantityGreatherThanZero);

        RuleFor(d => d.UnitPrice)
            .GreaterThan(0)
            .WithMessage(CreateOrderMessages.UnitPriceGreatherThanZero);



    }

}
