using Microsoft.Extensions.DependencyInjection.Extensions;
using MockDatabase.API;
using MockDatabase.Context;
using System;
using System.Collections.Generic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {

        /// <summary>
        /// Add a singleton instance of a populated TContext to the IServiceCollection
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="serviceCollection"></param>
        /// <param name="builder"></param>
        /// <returns></returns>

        public static IServiceCollection AddMockDatabaseDb<TContext>(this IServiceCollection serviceCollection, Action<SeedingConfigurationBuilder<TContext>> builder = null) where TContext : MockContext
        {
            SeedingConfigurationBuilder<TContext> builderObj = new SeedingConfigurationBuilder<TContext>();

            builder?.Invoke(builderObj);

            serviceCollection.TryAdd(new ServiceDescriptor(typeof(TContext), builderObj.Build()));

            return serviceCollection;


            
           
        }
       
    }
}
