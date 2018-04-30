using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MockDatabase.API;
using MockDatabase.Context;
using MockDatabase.Loader;
using MockDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MockDatabase.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMockDatabaseDb<TContext>(this IServiceCollection serviceCollection, Action<SeedingConfigurationBuilder<TContext>> builder = null) where TContext : MockContext
        {
            SeedingConfigurationBuilder<TContext> builderObj = new SeedingConfigurationBuilder<TContext>();

            builder?.Invoke(builderObj);

            serviceCollection.TryAdd(new ServiceDescriptor(typeof(TContext), builderObj.Build()));

            return serviceCollection;

            
           
        }
       
    }
}
