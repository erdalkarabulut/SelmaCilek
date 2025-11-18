using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bps.Core.Utilities.Helpers
{
	public static class CloneHelper
	{
		public static T DeepCopy<T> (this T obj) where T : class, new()
		{
			string tmpStr = JsonConvert.SerializeObject(obj);
			T newObject = JsonConvert.DeserializeObject<T>(tmpStr);
			return newObject;
		}

		public static List<T> DeepCopyAll<T>(this List<T> list)
		{
			string tmpStr = JsonConvert.SerializeObject(list);
			List<T> returnList = JsonConvert.DeserializeObject<List<T>>(tmpStr);
			return returnList;
		}

        public static Dictionary<string, object> FindDifferences<T>(T oldEntity, T newEntity)
        {
            var changes = new Dictionary<string, object>();
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                var oldValue = prop.GetValue(oldEntity);
                var newValue = prop.GetValue(newEntity);

                if (!Equals(oldValue, newValue))
                {
                    changes[prop.Name] = oldValue; 
                }
            }

            return changes; 
        }

        
        public static void RevertChanges<T>(T entity, Dictionary<string, object> changes)
        {
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                if (changes.ContainsKey(prop.Name))
                {
                    prop.SetValue(entity, changes[prop.Name]);
                }
            }
        }
    }
}
