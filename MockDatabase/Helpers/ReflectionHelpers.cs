using MockDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MockDatabase.Helpers
{
    public static class ReflectionHelpers
    {
        /// <summary>
        /// Get MockCollection PropertyInfo from TContext
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetMockCollectionsFromContext<TContext>() where TContext : MockContext
        {
            return GetMockCollectionsFromContext(typeof(TContext));
        }

        public static IEnumerable<PropertyInfo> GetMockCollectionsFromContext(Type context)
        {
            return context.GetProperties()
                                   .Where(p => p.PropertyType.Name.Contains("MockCollection"));
        } 


        /// <summary>
        /// Check if type is appears in a MockCollection property on a given TContext
        /// </summary>
        /// <param name="context">Type of the context</param>
        /// <param name="type">MockCollection generic type param</param>
        /// <returns>True if yes</returns>
        public static bool IsMockCollection(Type context, Type type)
        {
            var collections = GetMockCollectionsFromContext(context).Select(c => c.PropertyType.GenericTypeArguments[0].Name);

            if (!collections.Any(c => c.Contains(type.Name))) return false;

            return true;
        }

        /// <summary>
        /// Check if type implements IEnumerable
        /// </summary>
        /// <param name="type"></param>
        /// <returns>bool</returns>
        public static bool IsEnumerableType(this Type type)
        {
            if (type.GetInterfaces().Where(p => p.Name.Contains("IEnumerable")).Count() > 0) return true;
            return false;
        }

  

       
    }
}
