using System;
using System.Linq;
using System.Reflection;
using Bps.Core.CrossCuttingConcerns.Logging;
using Bps.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Bps.Core.Response;
using Bps.Core.Web.Session;
using FluentValidation;
using PostSharp.Aspects;

namespace Bps.Core.Aspects.Postsharp.ValidationAspects
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t != null && t.GetType() == entityType);

            foreach (var entity in entities)
            {
                var validationResult = ValidatorTool.FluentValidate(validator, entity);
                if (validationResult.Status == ResponseStatusEnum.ERROR)
                {
                    var newLine = "</br>";

                    var global = args.Method.GetParameters().Select((t, i) => new LogParameter
                    {
                        Name = t.Name,
                        Type = t.ParameterType.Name,
                        Value = args.Arguments.GetArgument(i)
                    }).FirstOrDefault(w => w.Name == "global");

                    if (global != null)
                    {
                        newLine = global.Value.GetType().GetProperty("KaynakKod")?.GetValue(global.Value, null) == "4" ? "</br>" : "\n";
                    }
                    var ex = new Exception(String.Join(newLine, validationResult.Items.ToArray()));
                    args.Exception = ex;
                    OnException(args);
                    return;
                }
            }
        }

        public override void OnException(MethodExecutionArgs args)
        {
            var methodReturnType = ((System.Reflection.MethodInfo)args.Method).ReturnType;
            var calcInstance = Activator.CreateInstance(methodReturnType);

            PropertyInfo messagePropertyInfo = methodReturnType.GetProperty("Message");
            PropertyInfo statusPropertyInfo = methodReturnType.GetProperty("Status");
            PropertyInfo exceptionPropertyInfo = methodReturnType.GetProperty("Error");

            messagePropertyInfo.SetValue(calcInstance, args.Exception.Message, null);
            statusPropertyInfo.SetValue(calcInstance, ResponseStatusEnum.WARNING, null);
            //exceptionPropertyInfo.SetValue(calcInstance, args.Exception, null);

            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = calcInstance;
        }
    }
}