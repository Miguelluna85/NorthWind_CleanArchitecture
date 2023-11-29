namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor : ICreateOrderInputPort
{
    readonly ICreateOrderOutputPort OutPutPort;
    readonly ICommandsRepository Repository;
    readonly IEnumerable< IModelValidator<CreateOrderDto>> Validators;
    

    public CreateOrderInteractor(
        ICreateOrderOutputPort outputPort,
        ICommandsRepository repository,
        IEnumerable<IModelValidator<CreateOrderDto>> validators)
    {
        OutPutPort = outputPort;
        Repository = repository;
        Validators = validators;

    }
    public async ValueTask Handle(CreateOrderDto orderDto)
    {
        //if (!await Validator.Validate(orderDto))
        //{
        //    string Errors = string.Join(" ",
        //        Validator.Errors
        //        .Select(e => $"{e.PropertyName}: {e.Message}"));
        //    throw new Exception(Errors);

        //}

        var Enumerator = Validators.GetEnumerator();

        bool isValid = true;

        while (isValid && Enumerator.MoveNext())
        {
            isValid = await Enumerator.Current.Validate(orderDto);
            if (!isValid)
            {
                //string Errors = string.Join(" ",
                //    Enumerator.Current.Errors
                //    .Select(e => $"{e.PropertyName}: {e.Message}"));

                throw new ValidationException(Enumerator.Current.Errors);
                //throw new Exception(Errors);
            }

        }

        OrderAggregate Order = OrderAggregate.From(orderDto);

        //Order.CustomerId = "";
        await Repository.CreateOrder(Order);
        await Repository.SaveChanged();
        await OutPutPort.Handle(Order);

    }
}
