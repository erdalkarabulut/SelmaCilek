using System;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Transactions;
using Bps.Core.CrossCuttingConcerns.Caching;
using Bps.Core.CrossCuttingConcerns.Logging;
using Bps.Core.CrossCuttingConcerns.Logging.Log4Net;
using Bps.Core.Response;
using log4net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace Bps.Core.Aspects.Postsharp.GenericAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class GenericAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;
        //private LoggerService _loggerServiceMail;
        //private TransactionScopeOption _option;

        private Type _cacheType;
        private int _cacheByMinute;
        private bool _useCache;
        private bool _useLog;
        private ICacheManager _cacheManager;

        public string cacheKey { get; set; }

        public GenericAspect(Type loggerType, Type cacheType, bool useCache = true, bool useLog = true, int cacheByMinute = 120)
        {
            _loggerType = loggerType;
            _cacheType = cacheType;
            _cacheByMinute = cacheByMinute;
            _useCache = useCache;
            _useLog = useLog;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                args.MethodExecutionTag = new TransactionScope(TransactionScopeOption.Required,
                     new TransactionOptions
                     {
                         Timeout = TimeSpan.FromMinutes(5) // 5 dakikaya çıkardık
                     });

                #region Log

                if (_useLog)
                {
                    LogicalThreadContext.Properties["userKod"] = DBNull.Value;
                    LogicalThreadContext.Properties["projeKod"] = DBNull.Value;
                    LogicalThreadContext.Properties["kaynakKod"] = DBNull.Value;
                    LogicalThreadContext.Properties["isCompare"] = DBNull.Value;
                    LogicalThreadContext.Properties["teknAd"] = DBNull.Value;
                    LogicalThreadContext.Properties["tableId"] = DBNull.Value;

                    var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                    {
                        Name = t.Name,
                        Type = t.ParameterType.Name,
                        Value = args.Arguments.GetArgument(i)
                    }).ToList();

                    var loginParam = args.Method.GetParameters().Select((t, i) => new LogParameter
                    {
                        Name = t.Name,
                        Type = t.ParameterType.Name,
                        Value = args.Arguments.GetArgument(i)
                    }).FirstOrDefault(w => w.Name == "param");

                    var global = args.Method.GetParameters().Select((t, i) => new LogParameter
                    {
                        Name = t.Name,
                        Type = t.ParameterType.Name,
                        Value = args.Arguments.GetArgument(i)
                    }).FirstOrDefault(w => w.Name == "global");

                    if (loginParam != null)
                    {
                        var userKod = loginParam.Value.GetType().GetProperty("KULKOD").GetValue(loginParam.Value, null);
                        LogicalThreadContext.Properties["userKod"] = userKod;
                        LogicalThreadContext.Properties["projeKod"] = "Login";
                    }
                    if (global != null)
                    {
                        var userKod = global.Value.GetType().GetProperty("UserKod")?.GetValue(global.Value, null);
                        var projeKod = global.Value.GetType().GetProperty("ProjeKod")?.GetValue(global.Value, null);
                        var kaynakKod = global.Value.GetType().GetProperty("KaynakKod")?.GetValue(global.Value, null);
                        var isCompare = global.Value.GetType().GetProperty("IsCompare")?.GetValue(global.Value, null);
                        var isCompareStr = isCompare != null && ((bool)isCompare) ? "1" : "0";

                        if (isCompareStr == "1")
                        {
                            if (logParameters.Count >= 2)
                            {
                                var memberInfo = logParameters[0].Value.GetType();
                                var memberInfoOld = logParameters[1].Value.GetType();
                                if (memberInfo == memberInfoOld)
                                {
                                    var baseType = memberInfo.Name;
                                    var baseTypeOld = memberInfoOld.Name;
                                    if (baseType == baseTypeOld)
                                    {
                                        var id = logParameters[0].Value.GetType().GetProperty("Id")
                                            ?.GetValue(logParameters[0].Value, null);
                                        LogicalThreadContext.Properties["teknAd"] = logParameters[0].Type;
                                        LogicalThreadContext.Properties["tableId"] = id;
                                    }
                                }
                            }
                        }

                        LogicalThreadContext.Properties["userKod"] = userKod;
                        LogicalThreadContext.Properties["projeKod"] = projeKod;
                        LogicalThreadContext.Properties["kaynakKod"] = kaynakKod;
                        LogicalThreadContext.Properties["isCompare"] = isCompare != null && ((bool)isCompare) ? "1" : "0";
                    }

                    var logDetail = new LogDetail
                    {
                        FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                        MethodName = args.Method.Name,
                        Parameters = logParameters,
                        Exception = null
                    };
                    _loggerService.Info(logDetail);
                }

                #endregion

                #region Cache

                // geçiçi kaldırıldı.
                _useCache = false;
                if (_useCache)
                {
                    var methodName = string.Format("{0}.{1}.{2}",
                        args.Method.ReflectedType.Namespace,
                        args.Method.ReflectedType.Name,
                        args.Method.Name);
                    var arguments = args.Arguments.ToList();

                    var key = string.Format("{0}({1})", methodName,
                        string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));

                    foreach (var arg in arguments)
                    {
                        if (arg != null)
                        {
                            var type = arg.GetType();
                            var properties = type.GetProperties().OrderBy(o => o.Name).ToList();
                            if (type.Name == "Global")
                            {
                                var propertiesG = properties.Where(w => w.Name == "SirketId" || w.Name == "ProjeKod" || w.Name == "MenuTag" /*|| w.Name == "UserKod"*/);/* || w.Name == "UserKod"*/
                                foreach (var prop1 in propertiesG)
                                {
                                    if (prop1 != null)
                                    {
                                        if (prop1.DeclaringType != null && prop1.DeclaringType.Name != "String")
                                        {
                                            var value = prop1.GetValue(arg);
                                            key = key + value;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (var prop in properties)
                                {
                                    if (prop.DeclaringType != null && prop.DeclaringType.Name != "String")
                                    {
                                        var value = prop.GetValue(arg);
                                        key = key + value;
                                    }
                                }
                            }
                        }
                    }
                    cacheKey = key;
                    if (_cacheManager.IsAdd(key))
                    {
                        args.FlowBehavior = FlowBehavior.Return;
                        args.ReturnValue = _cacheManager.Get<object>(key);
                        ((TransactionScope)args.MethodExecutionTag).Dispose();
                    }
                }

                #endregion
            }
            catch (Exception e)
            {
            }
        }

        public override void OnException(MethodExecutionArgs args)
        {
            string errorMessage = "";
            if (args.Exception != null)
            {
                if (args.Exception.InnerException != null) errorMessage = args.Exception.InnerException.Message;
                else
                {
                    if (args.Exception.GetType().ToString().Contains("DbEntityValidationException"))
                    {
                        DbEntityValidationException entValEx = args.Exception as DbEntityValidationException;
                        foreach (DbEntityValidationResult res in entValEx.EntityValidationErrors)
                        {
                            foreach (var err in res.ValidationErrors)
                            {
                                errorMessage += (err.ErrorMessage + Environment.NewLine);
                            }
                        }
                    }
                    else errorMessage = args.Exception.Message;
                }
            }

            try
            {
                if (_loggerService != null)
                {
                    LogicalThreadContext.Properties["userKod"] = DBNull.Value;
                    LogicalThreadContext.Properties["projeKod"] = DBNull.Value;
                    LogicalThreadContext.Properties["kaynakKod"] = DBNull.Value;
                    LogicalThreadContext.Properties["isCompare"] = DBNull.Value;
                    LogicalThreadContext.Properties["teknAd"] = DBNull.Value;
                    LogicalThreadContext.Properties["tableId"] = DBNull.Value;

                    var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                    {
                        Name = t.Name,
                        Type = t.ParameterType.Name,
                        Value = args.Arguments.GetArgument(i)
                    }).ToList();

                    var global = logParameters.FirstOrDefault(w => w.Name == "global");

                    var loginParam = logParameters.FirstOrDefault(w => w.Name == "param");

                    if (loginParam != null)
                    {
                        var userKod = loginParam.Value.GetType().GetProperty("KULKOD").GetValue(loginParam.Value, null);
                        LogicalThreadContext.Properties["userKod"] = userKod;
                    }

                    if (global != null)
                    {
                        var userKod = global.Value.GetType().GetProperty("UserKod")?.GetValue(global.Value, null);
                        var projeKod = global.Value.GetType().GetProperty("ProjeKod")?.GetValue(global.Value, null);
                        var kaynakKod = global.Value.GetType().GetProperty("KaynakKod")?.GetValue(global.Value, null);

                        LogicalThreadContext.Properties["userKod"] = userKod;
                        LogicalThreadContext.Properties["projeKod"] = projeKod;
                        LogicalThreadContext.Properties["kaynakKod"] = kaynakKod;
                    }

                    var logDetail = new LogDetail
                    {
                        FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                        MethodName = args.Method.Name,
                        Parameters = logParameters,
                        Exception = args.Exception
                    };

                    _loggerService.Error(logDetail);
                    //if (!string.IsNullOrEmpty(args.Exception.Source) && args.Exception.Source != "BusinessException")
                    //{
                    //    _loggerServiceMail = (LoggerService)Activator.CreateInstance(typeof(EmailLogger));
                    //    _loggerServiceMail.Error(args.Exception);
                    //}
                }

                var methodReturnType = ((System.Reflection.MethodInfo)args.Method).ReturnType;
                var calcInstance = Activator.CreateInstance(methodReturnType);

                PropertyInfo messagePropertyInfo = methodReturnType.GetProperty("Message");
                PropertyInfo statusPropertyInfo = methodReturnType.GetProperty("Status");
                //PropertyInfo exceptionPropertyInfo = methodReturnType.GetProperty("Error");

                var error = GetMessageByExType(args.Exception);
                messagePropertyInfo.SetValue(calcInstance,
                    error.Status == ResponseStatusEnum.OK ? error.Nesne : args.Exception.Message, null);
                statusPropertyInfo.SetValue(calcInstance, ResponseStatusEnum.ERROR, null);
                //exceptionPropertyInfo.SetValue(calcInstance, args.Exception, null);

                args.FlowBehavior = FlowBehavior.Return;
                args.ReturnValue = calcInstance;
            }
            catch (Exception e)
            {
                Exception ex = new Exception(e.Message + Environment.NewLine + errorMessage);
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            if (args.MethodExecutionTag == null) return; //Servis formdan işlerken null gelebiliyor. Bakılacak
            ((TransactionScope)args.MethodExecutionTag).Complete();
            if (_useCache)
            {
                if (!_cacheManager.IsAdd(cacheKey))
                    _cacheManager.Add(cacheKey, args.ReturnValue, _cacheByMinute);
            }
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            try
            {
                if (args.MethodExecutionTag == null) return;
                ((TransactionScope)args.MethodExecutionTag).Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(args.ReturnValue.ToString());
            }
        }

        public StandardResponse<string> GetMessageByExType(Exception ex)
        {
            var sonuc = new StandardResponse<string>();
            try
            {
                SqlException innerException = null;
                Exception tmp = ex;
                while (innerException == null && tmp != null)
                {
                    if (tmp != null)
                    {
                        innerException = tmp.InnerException as SqlException;
                        tmp = tmp.InnerException;
                    }
                }
                if (innerException != null && innerException.Number == 2601)
                {
                    sonuc.Nesne = "Aynı kayıt tekrar girilemez!";
                    sonuc.Status = ResponseStatusEnum.OK;
                    return sonuc;
                }

                sonuc.Status = ResponseStatusEnum.ERROR;
            }
            catch (Exception e)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }
            return sonuc;
        }
    }
}