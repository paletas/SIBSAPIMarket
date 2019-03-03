using Microsoft.Extensions.DependencyInjection;
using SIBSAPIMarket.Client.Configuration;
using System;

namespace SIBSAPIMarket.Client
{
    public static class ServiceLocatorExtensions
    {
        public static IServiceCollection ConfigureMarketAPI(this IServiceCollection serviceCollection, string baseApiPath)
        {
            serviceCollection.AddSingleton<Endpoints>(new Endpoints(new Uri(baseApiPath)));

            return serviceCollection;
        }
    }
}
