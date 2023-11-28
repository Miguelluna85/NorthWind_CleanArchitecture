using Microsoft.AspNetCore.Builder;

namespace NorthWind.Sales.Backend.IoC;

public static class EndpointsContainer
{
    public static WebApplication MapNorthWindSalesEndPoints(
        this WebApplication app)
    {
        app.UseCreateOrderController();

        return app;
    }
}
