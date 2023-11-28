using NorthWind.Sales.Backend.Presenters.ExceptionHandlers;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddPresenters
        (this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderOutputPort, CreateOrderPresenter>();

        services.AddKeyedSingleton<object,
                ValidationExceptionHandler>(typeof(IExceptionHandler<>));

        services.AddKeyedSingleton<object,
        UnitOfWorkException>(typeof(IExceptionHandler<>));

        services.AddSingleton<ExceptionHandlerOrchestrator>();

        return services;
    }

}
