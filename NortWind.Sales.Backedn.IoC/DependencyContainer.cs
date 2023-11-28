//using Microsoft.Extensions.DependencyInjection;

//namespace NorthWind.Sales.Backend.IoC;
namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices(
        this IServiceCollection services,
        Action<DBOptions> configureDbOptions)
    {
        services
            .AddUseCasesServices()
            .AddRepositories(configureDbOptions)
            .AddPresenters()
            .AddValidators();

        return services;
    }
}
