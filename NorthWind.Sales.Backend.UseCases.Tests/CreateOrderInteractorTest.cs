namespace NorthWind.Sales.Backend.UseCases.Tests
{
    public class CreateOrderInteractorTest
    {
        [Fact]
        public async void CreateOrder_ReturnsIdGreatherThanZero()
        {
            //Arrange
            var StubRepository = new RepositoryFalse();
            var MockPresenter = new PresenterFake();
            var Order = new CreateOrderDto
            (
                customerId: "ALFKI",
                shipAddress: "3 oriente",
                shipCity: "puebla",
                shipCountry: "México",
                shipPostalCode: "12345",
                orderDetails: new List<CreateOrderDetailDto>
                { new
                CreateOrderDetailDto
                (
                    productId:1,
                    quantity:15,
                    unitPrice:17
                )
                }
            );
            //CreateOrderInteractor Interactor =
            //    new CreateOrderInteractor(MockPresenter, StubRepository);

            ////Act
            //await Interactor.Handle(Order);

            ////Assert
            //Assert.True(MockPresenter.OrderId > 0);
            //Assert.True(MockPresenter.Order.ShippingType == BusinessObjects.Enums.ShippingType.Air);
        }
    }
}