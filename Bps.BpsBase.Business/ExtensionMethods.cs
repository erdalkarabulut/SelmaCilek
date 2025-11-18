using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bps.BpsBase.Business
{
    public static class ExtensionMethods
    {
        //public static Int32 ToInt32(this object value)
        //{
        //    return Convert.ToInt32(value);
        //}

        public static List<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> sourceList)
	        where TDestination : new()
        {
	        var destinationList = new List<TDestination>();

	        var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
	        var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

	        var destPropertyDict = destinationProperties.ToDictionary(p => p.Name);

	        foreach (var sourceItem in sourceList)
	        {
		        var destinationItem = new TDestination();

		        foreach (var sourceProp in sourceProperties)
		        {
			        if (destPropertyDict.TryGetValue(sourceProp.Name, out var destProp))
			        {
				        if (destProp.PropertyType == sourceProp.PropertyType && destProp.CanWrite)
				        {
					        var value = sourceProp.GetValue(sourceItem);
					        destProp.SetValue(destinationItem, value);
				        }
			        }
		        }

		        destinationList.Add(destinationItem);
	        }

	        return destinationList;
        }
    }
}
