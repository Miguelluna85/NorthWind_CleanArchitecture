﻿namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices
        (this IServiceCollection services,
        Action<HttpClient> configureClient)
    {

        services
            .AddValidators()
            .AddWebApiGateways(configureClient)
            .AddViewServices();

        return services;
    }

}
