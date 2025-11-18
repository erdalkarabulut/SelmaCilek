using System.Globalization;
using Bps.Core.Web.Session;

namespace Bps.Core.Web.Formatter
{
    public static class CultureHelper
    {
        public static CultureInfo GetCulture()
        {
            var clt = CultureInfo.CreateSpecificCulture(SessionHelper.DilKod);
            clt.NumberFormat = CurrencyFormatter.GetTurkishFormat();
            return clt;
        }
    }
}