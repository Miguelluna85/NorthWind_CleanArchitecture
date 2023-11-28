//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();


using NorthWind.Sales.WebApi;

WebApplication.CreateBuilder(args)
    .CreateWebApplication()
    .ConfigureWebApplication()
    .Run();
