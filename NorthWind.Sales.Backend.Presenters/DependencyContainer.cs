﻿using Microsoft.AspNetCore.Builder;

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
        UnitOfWorkExceptionHandler>(typeof(IExceptionHandler<>));

        services.AddExceptionHandler<ExceptionHandlerOrchestrator>();
        services.AddExceptionHandler<UnhandledExceptionHandler>();  

        return services;
    }

    //public static WebApplication UseCustomExceptionHandlers(
    //     this WebApplication app)
    //{
    //    //var Orchertrator = app.Services
    //    //    .GetRequiredService<ExceptionHandlerOrchestrator>();

    //    //app.UseExceptionHandler(builder =>
    //    //    builder.Run(Orchertrator.HandleException));

    //    app.UseExceptionHandler(builder =>
    //        { });


    //    return app;
    //}

}
