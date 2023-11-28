namespace NorthWind.Sales.Backend.UseCases.Tests.Fake
{
    internal class RepositoryFalse : ICommandsRepository
    {
        OrderAggregate Order;
        public ValueTask CreateOrder(OrderAggregate order)
        {
            Order = order;
            return ValueTask.CompletedTask;
        }

        public ValueTask SaveChanged()
        {
            Order.Id = 1;
            return ValueTask.CompletedTask;

        }
    }
}
