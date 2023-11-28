namespace NorthWind.Sales.Entities.Validators.CreateOrder;

internal class CreateOrderDtoValidator 
    : ValidatorBase<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(c => c.CustomerId)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.CustomerIdRequeired)
            .Length(5)
            .WithMessage(CreateOrderMessages.CustomerIdRequiredLength);


        RuleFor(c => c.ShipAddress)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipAddressRequired)
            .MaximumLength(60)
            .WithMessage(CreateOrderMessages.ShipAddressMaximunLength);


        RuleFor(c => c.ShipCity)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCityRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCityMinimumLenth)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCityMaximumLength);


        RuleFor(c => c.ShipCountry)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.ShipCountryRequired)
            .MinimumLength(3)
            .WithMessage(CreateOrderMessages.ShipCityMinimumLenth)
            .MaximumLength(15)
            .WithMessage(CreateOrderMessages.ShipCountryMaximumLength);

        RuleFor(c => c.ShipPostalCode)
            .MaximumLength(10)
            .WithMessage(CreateOrderMessages.ShipPostalCodeMaximum);

        RuleFor(c => c.OrderDetails)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage(CreateOrderMessages.OrderDetailsRequired)
            .NotEmpty()
            .WithMessage(CreateOrderMessages.OrderDetailsNoEmpty);

        RuleForEach(c => c.OrderDetails)
            .SetValidator(new CreateOrderDetailDtoValidator());

    }
}
