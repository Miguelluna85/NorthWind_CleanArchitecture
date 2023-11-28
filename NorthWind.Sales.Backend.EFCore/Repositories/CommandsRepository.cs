namespace NorthWind.Sales.Backend.EFCore.Repositories;

internal class CommandsRepository : ICommandsRepository
{
    readonly NorthWindSalesContext Context;

    public CommandsRepository(NorthWindSalesContext context)
    {
        Context = context;
    }
    public async ValueTask CreateOrder(OrderAggregate order)
    {
        await Context.AddAsync(order);
        await Context.AddRangeAsync(
            order.OrderDetails
            .Select(d => new Entities.OrderDetail
            {
                Order = order,
                ProductId = d.ProductId,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice
            }
            ).ToArray());
    }

    public async ValueTask SaveChanged()
    {
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new UnitOfWorkException(ex,
                ex.Entries.Select(e => e.Entity.GetType().Name));
        }
        catch(Exception)
        {
            throw;
        }
    }
}
