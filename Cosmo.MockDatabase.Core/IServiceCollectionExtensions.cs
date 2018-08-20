using Cosmo.MockDatabase.Builders;
using Cosmo.MockDatabase.Context;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {

        public static IServiceCollection RegisterMockDatabase<TContext>(this IServiceCollection serviceCollection, Action<MockContextBuilder<TContext>> builder = null, int dbSize = 30) where TContext : MockContext
        {
            var builderObj = new MockContextBuilder<TContext>();
            
            builder?.Invoke(builderObj);

            serviceCollection.TryAdd(new ServiceDescriptor(typeof(TContext), builderObj.BuildDatabase(dbSize)));

            return serviceCollection;
        }

    }
}