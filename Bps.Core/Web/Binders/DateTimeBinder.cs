using System;
using System.Web.Mvc;
using Bps.Core.Web.Formatter;

namespace Bps.Core.Web.Binders
{
    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (!(value == null || string.IsNullOrEmpty(value.AttemptedValue) || value.AttemptedValue == "null"))
            {
                try
                {
                    return DateTime.Parse(value.AttemptedValue.Replace("\"", ""), CultureHelper.GetCulture());
                }
                catch
                {
                    // ignored
                }
            }
            return null;
        }
    }
}
