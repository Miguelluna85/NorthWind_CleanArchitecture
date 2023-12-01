namespace NorthWind.Sales.Backend.UseCases.CreateOrder;
internal class CreateOrderDBValidator :
    IModelValidator<CreateOrderDto>
{
    readonly IQueriesRepository Repository;
    public CreateOrderDBValidator(IQueriesRepository repository)
    {
        Repository = repository;
    }

    readonly List<ValidationError> ErrorsField = new();

    public IEnumerable<ValidationError> Errors =>
        ErrorsField;

    public async Task<bool> Validate(CreateOrderDto model)
    => await ValidateCustomer(model) &&
        await ValidatorProduct(model);

    private async Task<bool> ValidatorProduct(CreateOrderDto model)
    {
        IEnumerable<ProductUnitInStock> RequiredQuantities =
            model.OrderDetails
            .GroupBy(d => d.ProductId)
            .Select(d => new ProductUnitInStock(
                d.Key, (short)d.Sum(d => d.Quantity)));

        var ProductIds = RequiredQuantities
            .Select(d => d.ProductId);

        IEnumerable<ProductUnitInStock> InStockQuantities =
            await Repository.GetProductsUnitsInStock(ProductIds);

        var RequiredVsInStock =
                RequiredQuantities
                .GroupJoin(InStockQuantities,
                required => required.ProductId,
                inStock => inStock.ProductId,
                (oneRequired, manyInStock) => new { oneRequired, manyInStock })
                .SelectMany(groupResult =>
                groupResult.manyInStock.DefaultIfEmpty(),
                (groupResult, singleInStock) =>
                new
                {
                    groupResult.oneRequired.ProductId,
                    Required = groupResult.oneRequired.UnitsInStock,
                    InStock = singleInStock?.UnitsInStock
                });

        foreach (var Item in RequiredVsInStock)
        {
            if (!Item.InStock.HasValue)
            {
                CreateOrderDetailDto OrderDetail =
                    model.OrderDetails
                    .First(i => i.ProductId == Item.ProductId);
                var Index = model.OrderDetails.ToList().IndexOf(OrderDetail);
                string PropertyName =
                    $"{nameof(model.OrderDetails)}[{Index}].{nameof(OrderDetail.ProductId)}";

                ErrorsField.Add(new ValidationError(
                    PropertyName,
                    string.Format(CreateOrderMessages.ProductIdNotFoundErrorTemplate,
                   Item.ProductId)));
            }
            else if (Item.InStock < Item.Required)
            {
                CreateOrderDetailDto OrderDetail =
                   model.OrderDetails
                   .Last(i => i.ProductId == Item.ProductId);
                var Index = model.OrderDetails.ToList().IndexOf(OrderDetail);
                string PropertyName =
                    $"{nameof(model.OrderDetails)}[{Index}].{nameof(OrderDetail.Quantity)}";

                ErrorsField.Add(new ValidationError(
                PropertyName,
                string.Format(
                    CreateOrderMessages
                    .UnitInStockLessThanQuantityErrorTemplate,
                    Item.Required, Item.InStock, Item.ProductId)));
            }

        }
        return !ErrorsField.Any();
    }


    private async Task<bool> ValidateCustomer(CreateOrderDto model)
    {
        var CurrentBalance =
              await Repository
              .GetCustomerCurrentBalance(model.CustomerId);

        if (CurrentBalance == null)
        {
            ErrorsField.Add(new ValidationError(
                nameof(model.CustomerId),
                CreateOrderMessages.CustomerIdNotFoundError));
        }
        else if (CurrentBalance > 0)
        {
            ErrorsField.Add(new ValidationError(
                nameof(model.CustomerId),
                string.Format(CreateOrderMessages.CustomerWhitBalanceErrorTemplate,
                model.CustomerId, CurrentBalance)));
        }

        return !ErrorsField.Any();
    }



}

