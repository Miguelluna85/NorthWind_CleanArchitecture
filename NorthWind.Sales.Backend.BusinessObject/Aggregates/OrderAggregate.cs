namespace NorthWind.Sales.Backend.BusinessObjects.Aggregates
{
    public class OrderAggregate : Order
    {
        readonly List<OrderDetail> OrderDetailsFied = new List<OrderDetail>();

        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsFied;

        public void AddDetail(int productId, decimal unitPrice, short quantity)
        {
            var ExistingOrderDetails = OrderDetailsFied.FirstOrDefault(o => o.ProductId == productId);

            if (ExistingOrderDetails != default)
            {
                quantity += ExistingOrderDetails.Quantity;
                OrderDetailsFied.Remove(ExistingOrderDetails);
            }

            OrderDetailsFied.Add(new OrderDetail(productId, unitPrice, quantity));
        }

        public static OrderAggregate From(CreateOrderDto orderDto)
        {
            OrderAggregate Order = new OrderAggregate
            {
                CustomerId = orderDto.CustomerId,
                ShipAddress = orderDto.ShipAddress,
                ShipCity = orderDto.ShipCity,
                ShipCountry = orderDto.ShipCountry,
                ShipPostalCode = orderDto.ShipPostalCode
            };

            foreach (var Item in orderDto.OrderDetails)
            {
                Order.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
            }
            return Order;
        }



    }
}
