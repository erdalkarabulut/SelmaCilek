using System;
using System.Web.Mvc;

namespace Bps.Core.Web.Binders
{
    public class TimeSpanBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null)
            {
                return null;
            }
            var tmpValue = value.AttemptedValue.Replace("\"", "");
            TimeSpan trueValue;
            if (!TimeSpan.TryParse(tmpValue, out trueValue))
            {
                DateTime trueDate;
                if (DateTime.TryParse(tmpValue, out trueDate))
                {
                    trueValue = trueDate.TimeOfDay;
                }
            }
            return trueValue;
        }
    }
}
