using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;
using Bps.Core.Utilities.Extensions;

namespace Bps.Core.Utilities.Helpers
{
    public static class EnumHelper
    {

        public static List<ListItem> GetListItemsFromEnum<T>() where T : struct, IConvertible
        {
            var sonuc = new List<ListItem>();
            System.Array enumValues = System.Enum.GetValues(typeof(T));
            for (int i = 0; i < enumValues.Length; i++)
            {
                int intValue = (int)enumValues.GetValue(i);
                sonuc.Add(new ListItem(enumValues.GetValue(i).ToDescription(), intValue.ToString()));
            }
            return sonuc;
        }

        //enumextensions.cs içerisinde benzer bir fonksyion var.
        public static string GetDescriptionFromEnumValue(Enum value)
        {
            if (value == null) return null;
            if (value.ToString() == "0") return null;

            DescriptionAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}