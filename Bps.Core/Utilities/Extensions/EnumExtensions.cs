using System;
using System.ComponentModel;
using System.Linq;

namespace Bps.Core.Utilities.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription<TEnum>(this TEnum value)
        {

            if (value == null) return "";
            var attr = value.GetType().GetField(value.ToString());

            if (attr == null)
            {
                return "";
            }
            else
            {
                var attributes = (DescriptionAttribute[])attr.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }

        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null) return null;
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}