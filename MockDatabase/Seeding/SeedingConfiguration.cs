using MockDatabase.Context;
using MockDatabase.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MockDatabase.Seeding
{
    /// <summary>
    /// Default Implementation of an ISeedingConfiguration
    /// </summary>
    /// <typeparam name="TContext">Concrete implementation of MockContext</typeparam>

    public class SeedingConfiguration<TContext> : ISeedingConfiguration<TContext> where TContext : MockContext
    {
        private Dictionary<string, IMockCollectionSeedingProfile> _seedingProfiles = new Dictionary<string, IMockCollectionSeedingProfile>();

        /// <summary>
        /// AddSeedingProfile for a single MockCollection existing on a given TContext
        /// </summary>
        /// <param name="seedingProfile"></param>
        public void AddSeedingProfile(IMockCollectionSeedingProfile seedingProfile)
        {
            _seedingProfiles.Add(seedingProfile.ClassName, seedingProfile);
        }

        /// <summary>
        /// Load SeedingProfiles for MockCollections that do not use user-defined data for any properties
        /// </summary>
        private void LoadDefaultSeedingProfiles()
        {
            var mockCollections = typeof(TContext).GetProperties()
                                             .Where(p => p.PropertyType.Name.Contains("MockCollection"))
                                             .Select(m => m.PropertyType.GenericTypeArguments[0]);

            foreach (var classArg in mockCollections)
            {
                if (!_seedingProfiles.ContainsKey(classArg.Name))
                {
                    //_seedingProfiles.Add(classArg.Name, new DefaultMockCollectionSeedingProfile(classArg));
                    _seedingProfiles.Add(classArg.Name, (IMockCollectionSeedingProfile)Activator.CreateInstance(typeof(MockCollectionSeedingProfile<>).MakeGenericType(classArg)));
                }
            }
        }

        /// <summary>
        /// Get the fully seeded TContext instance
        /// </summary>
        /// <param name="count">Number of entries per MockCollection</param>
        /// <returns>TContext object</returns>
        public TContext SeedDatabase(int count)
        {
            LoadDefaultSeedingProfiles();

            var instance = Activator.CreateInstance(typeof(TContext));
            Dictionary<PropertyInfo, List<object>> tempDict = new Dictionary<PropertyInfo, List<object>>();


            var outerObjList = new List<object>();

            var mockCollections = ReflectionHelpers.GetMockCollectionsFromContext<TContext>();


            while(outerObjList.Count < count * mockCollections.Count())
            {
                var objList = new List<object>();

                foreach (var seedingProfile in _seedingProfiles)
                {
                    var entry = seedingProfile.Value.GetClassEntry();
                    objList.Add(entry);
                }

                JoinObjects(instance, objList);

                outerObjList.AddRange(objList);


            }

            foreach (var mockCollection in mockCollections)
            {
                mockCollection.GetSetMethod().Invoke(instance, new object[] { Activator.CreateInstance(mockCollection.PropertyType) });
                var data = outerObjList.Where(o => o.GetType() == mockCollection.PropertyType.GenericTypeArguments[0]);

                ((IMockCollection)mockCollection.GetValue(instance)).AddData(data.ToList());
                
            }





            return (TContext)instance;

        }

        private void JoinObjects(object instance, List<object> objList)
        {

            //finally this is working
            //now fix for collections

            foreach(var obj in objList)
            {
                var properties = obj.GetType().GetProperties();
                foreach(var prop in properties)
                {
                    if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                    {
                        var corresponding = objList.Single(o => o.GetType() == prop.PropertyType);

                        prop.SetValue(obj, corresponding);
                    }

                    if(prop.PropertyType.IsEnumerableType() && prop.PropertyType != typeof(string))
                    {
                        var corresponding = objList.Single(o => o.GetType() == prop.PropertyType.GenericTypeArguments[0]);

                        var collectionType = prop.PropertyType.GenericTypeArguments[0];
                        var listObj = Activator.CreateInstance((typeof(List<>).MakeGenericType(collectionType)));
                        ((IList)listObj).Add(corresponding);

                        var correspondingProp = corresponding.GetType().GetProperties().FirstOrDefault(p => p.PropertyType == collectionType);
                        if (correspondingProp != null) correspondingProp.SetValue(corresponding, prop);

                        prop.SetValue(obj, listObj);
                    }
                }
            }
        }

        
    }
}
