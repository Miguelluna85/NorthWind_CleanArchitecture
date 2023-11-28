var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddNorthWindSalesServices(HttpClient =>
{
    HttpClient.BaseAddress =
    new Uri(builder.Configuration["webApiAddress"]);
}
);


await builder.Build().RunAsync();
