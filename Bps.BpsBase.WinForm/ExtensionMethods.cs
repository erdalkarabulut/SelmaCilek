using System;
using System.Collections.Generic;

namespace BPS.Windows.Forms
{
    public static class ExtensionMethods
    {
        public static Int32 ToInt32(this object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
