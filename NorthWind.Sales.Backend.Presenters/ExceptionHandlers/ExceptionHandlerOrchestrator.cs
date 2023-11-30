namespace NorthWind.Sales.Backend.Presenters.ExceptionHandlers;
internal class ExceptionHandlerOrchestrator : IExceptionHandler
{
    readonly Dictionary<Type, object> Handlers;
    // readonly ILogger<ExceptionHandlerOrchestrator> Logger;

    public ExceptionHandlerOrchestrator(
       [FromKeyedServices(typeof(IExceptionHandler<>))]
        IEnumerable<object> handlers
        //,ILogger<ExceptionHandlerOrchestrator> logger
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
        //Logger = logger;
    }


    //ProblemDetails TOProblemDetail(Exception exception)
    //{
    //    ProblemDetails Details;
    //    if (Handlers.TryGetValue(exception.GetType(),
    //        out object Handler))
    //    {
    //        Type HandlerType = Handler.GetType();
    //        Details = (ProblemDetails)HandlerType
    //            .GetMethod(
    //            nameof(IExceptionHandler<Exception>.Handle))
    //            .Invoke(Handler, new object[] { exception });
    //    }
    //    else
    //    {
    //        Details = new ProblemDetails();
    //        Details.Status = StatusCodes.Status500InternalServerError;
    //        Details.Type =
    //            "https://datatracker.ietf.org/doc/html/rfc7231#sectiob-6.6.1";
    //        Details.Title = ExceptionMessages.UnhandledExceptionTitle;
    //        Details.Detail = ExceptionMessages.UnhandledExceptionDetail;
    //        Details.Instance =
    //            $"{nameof(ProblemDetails)}/{exception.GetType()}";

    //        Logger.LogError(exception,
    //            ExceptionMessages.UnhandledExceptionTitle);
    //    }
    //    return Details;
    //}

    //public async Task HandleException(HttpContext context)
    //{
    //    IExceptionHandlerFeature ExceptionDetail =
    //        context.Features.Get<IExceptionHandlerFeature>();
    //    Exception Exception = ExceptionDetail.Error;

    //    if (Exception != null)
    //    {
    //        var ProblemDetail = TOProblemDetail(Exception);
    //        //context.Response.ContentType = "application/problem+json";
    //        //context.Response.StatusCode = ProblemDetail.Status.Value;

    //        //var Stream = context.Response.Body;
    //        //await JsonSerializer.SerializeAsync(Stream, ProblemDetail);

    //        await context.WriteProblemDetails(ProblemDetail);

    //    }

    //}

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        bool Handled = false;

        if (Handlers.TryGetValue(exception.GetType(),
            out object Handler))
        {
            Type HandlerType = Handler.GetType();
            ProblemDetails Details = (ProblemDetails)HandlerType
                .GetMethod(nameof(IExceptionHandler<Exception>.Handle))
                .Invoke(Handler, new object[] { exception });

            await httpContext.WriteProblemDetails(Details);
            Handled = true;
        }



        return Handled;
    }
}
