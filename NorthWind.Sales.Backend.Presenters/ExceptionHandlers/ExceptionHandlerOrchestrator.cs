namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers;
internal class ExceptionHandlerOrchestrator
{
    readonly Dictionary<Type, object> Handlers;
    readonly ILogger<ExceptionHandlerOrchestrator> Logger;
    public ExceptionHandlerOrchestrator(
       [FromKeyedServices(typeof(IExceptionHandler<>))]
        IEnumerable<object> handlers,
        ILogger<ExceptionHandlerOrchestrator> logger
        )
    {
        Handlers = new();
        foreach (var Handler in handlers)
        {
            Type ExceptionType = Handler.GetType()
                .GetInterfaces().First(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>))
                .GetGenericArguments()[0];

            Handlers.TryAdd(ExceptionType, Handler);

        }
        Logger = logger;
    }


    //TODO: Implementar


}
