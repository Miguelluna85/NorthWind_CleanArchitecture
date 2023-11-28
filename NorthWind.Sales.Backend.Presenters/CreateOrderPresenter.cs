using NorthWind.Sales.Backend.BusinessObjects.Aggregates;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

namespace NorthWind.Sales.Backend.Presenters
{
    internal class CreateOrderPresenter : ICreateOrderOutputPort
    {
        public int OrderId { get; private set; }

        public ValueTask Handle(OrderAggregate addedOrder)
        {
            OrderId = addedOrder.Id;
            return ValueTask.CompletedTask;
        }
    }
}
