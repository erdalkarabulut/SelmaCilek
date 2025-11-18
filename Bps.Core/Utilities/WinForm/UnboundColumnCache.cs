using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.Extensions;

namespace Bps.Core.Utilities.WinForm
{
    public class UnboundColumnCache
    {
        public bool getSet = false;

        private readonly string _KeyFieldName;
        Dictionary<object, object> valuesCache = new Dictionary<object, object>();

        public UnboundColumnCache(string keyFieldName)
        {
            _KeyFieldName = keyFieldName;
        }

        public object GetValue(object row)
        {
            return GetValueByKey(row);
        }

        public object GetValueByKey(object key)
        {
            if (key == null) return null;
            object result = null;
            valuesCache.TryGetValue(key, out result);
            return result;
        }

        public void SetValue(object row, object value)
        {
            valuesCache[row] = value;
        }
    }
}
