using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Bps.Core.Web.Extensions
{
    public static class ExpressionExtensions
    {
        public static Dictionary<string, Type> GetExpressionProperties<TModel>(
            this Expression<Func<TModel, object>> excludedProperties)
        {
            var result = new Dictionary<string, Type>();
            var memberExpr = excludedProperties.Body as MemberExpression;
            if (memberExpr == null)
            {
                PropertyInfo[] properties = excludedProperties.Body.Type.GetProperties();
                foreach (PropertyInfo propertyInfo in properties)
                {
                    result.Add(propertyInfo.Name, propertyInfo.PropertyType.GetPropertyBaseType());
                }
            }
            else if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                result.Add(memberExpr.Member.Name, memberExpr.Member.GetType().GetPropertyBaseType());

            return result;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            ParameterExpression param = expr1.Parameters[0];
            if (ReferenceEquals(param, expr2.Parameters[0]))
            {
                return Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(expr1.Body, expr2.Body), param);
            }

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    expr1.Body,
                    Expression.Invoke(expr2, param)), param);

        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> a, Expression<Func<T, bool>> b)
        {
            Expression body = Expression.OrElse(a.Body, b.Body);
            return Expression.Lambda<Func<T, bool>>(body);
        }
    }
}
