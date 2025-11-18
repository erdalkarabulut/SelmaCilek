using System.Globalization;

namespace Bps.Core.Web.Formatter
{
    public static class CurrencyFormatter
    {
        public static NumberFormatInfo GetTurkishFormat()
        {
            NumberFormatInfo info = new NumberFormatInfo();
            info.CurrencyDecimalSeparator = ",";
            info.CurrencyGroupSeparator = ".";
            info.NumberDecimalSeparator = ",";
            info.NumberGroupSeparator = ".";
            info.CurrencySymbol = "TL";
            info.CurrencyPositivePattern = 3;
            info.CurrencyNegativePattern = 8;
            return info;
        }
    }
}