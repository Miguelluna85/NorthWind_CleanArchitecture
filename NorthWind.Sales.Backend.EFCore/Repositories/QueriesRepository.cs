namespace NorthWind.Sales.Backend.EFCore.Repositories;

internal class QueriesRepository : IQueriesRepository
{
    readonly NorthWindSalesContext Context;
    public QueriesRepository(NorthWindSalesContext context)
    => Context = context;

    public async Task<decimal?> GetCustomerCurrentBalance(string customerId)
    {
        var Result = await Context.Customers
             .Where(c => c.Id == customerId)
            .Select(c => new { c.CurrentBalance })
            .FirstOrDefaultAsync();

        return Result?.CurrentBalance;
    }

    public async Task<IEnumerable<ProductUnitInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds)
    {
        return await Context.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => new ProductUnitInStock(
                p.Id, p.UnitsInStock))
            .ToListAsync();
    }
}
