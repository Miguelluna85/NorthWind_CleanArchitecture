namespace NorthWind.Sales.Backend.BusinessObjects.ValueObjects;
public class ProductUnitInStock
{
    public int ProductId { get; }
    public short UnitsInStock { get; }

    public ProductUnitInStock(int productId, short unitsInStock)
    {
        ProductId = productId;
        UnitsInStock = unitsInStock;
    }

    //public ProductUnitInStock(int productId, short unitInStock)
    //{
    //    ProductId = productId;
    //    UnitsInStock = unitInStock;
    //}
}
