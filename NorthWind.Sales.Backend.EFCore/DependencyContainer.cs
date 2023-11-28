namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        Action<DBOptions> configureDbOptions)
    {
        services.Configure(configureDbOptions);
        services.AddDbContext<NorthWindSalesContext>( );
        services.AddScoped<ICommandsRepository, CommandsRepository>();
        services.AddScoped<IQueriesRepository, QueriesRepository>();
        return services;
    }
}
