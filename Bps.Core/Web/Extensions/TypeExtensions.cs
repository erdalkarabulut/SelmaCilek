using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bps.Core.Web.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        ///     İlgili modelin özelliklerini istenilen özellikleri çıkartılarak geri döndürür.
        /// </summary>
        /// <typeparam name="TModel">Model</typeparam>
        /// <param name="excludedProperties">Listeden çıkartılacak özellikler</param>
        /// <returns>Özelliğin Adı ve Türünü Dictionary olarak döndürür.</returns>
        public static Dictionary<string, Type> GetPropertiesDictionary<TModel>(
            Expression<Func<TModel, object>> excludedProperties = null)
        {
            var result = new Dictionary<string, Type>();
            var excludedFields = new List<string>();
            if (excludedProperties != null)
            {
                var memberExpr = excludedProperties.Body as MemberExpression;
                if (memberExpr == null)
                {
                    PropertyInfo[] properties = excludedProperties.Body.Type.GetProperties();
                    excludedFields.AddRange(properties.Select(propertyInfo => propertyInfo.Name));
                }
                else if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                    excludedFields.Add(memberExpr.Member.Name);
            }

            Type modelType = typeof(TModel);
            foreach (PropertyInfo propertyInfo in modelType.GetProperties())
            {
                if (excludedFields.Contains(propertyInfo.Name) || result.ContainsKey(propertyInfo.Name))
                {
                    continue;
                }

                result.Add(propertyInfo.Name, propertyInfo.PropertyType.GetPropertyBaseType());
            }
            return result;
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyRefExpr)
        {
            if (propertyRefExpr == null)
                throw new ArgumentNullException("propertyRefExpr", "propertyRefExpr is null.");

            var memberExpr = propertyRefExpr as MemberExpression ?? propertyRefExpr.Body as MemberExpression;
            if (memberExpr == null)
            {
                var unaryExpr = propertyRefExpr.Body as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    memberExpr = unaryExpr.Operand as MemberExpression;
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                return memberExpr.Member.Name;

            return null;
        }

        public static string GetPropertyName<T, Y>(Expression<Func<T, Y>> propertyRefExpr)
        {
            if (propertyRefExpr == null)
                throw new ArgumentNullException("propertyRefExpr", "propertyRefExpr is null.");

            var memberExpr = propertyRefExpr as MemberExpression ?? propertyRefExpr.Body as MemberExpression;
            if (memberExpr == null)
            {
                var unaryExpr = propertyRefExpr.Body as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    memberExpr = unaryExpr.Operand as MemberExpression;
                else
                {
                }
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                return memberExpr.Member.Name;

            return null;
        }

        public static string[] GetPropertyNames<T>(Expression<Func<T, object>> propertyRefExpr)
        {
            var fields = new List<string>();
            if (propertyRefExpr == null)
                throw new ArgumentNullException("propertyRefExpr", "propertyRefExpr is null.");

            var memberExpr = propertyRefExpr as MemberExpression ?? propertyRefExpr.Body as MemberExpression;
            if (memberExpr == null)
            {
                var unaryExpr = propertyRefExpr.Body as UnaryExpression;
                if (unaryExpr != null && unaryExpr.NodeType == ExpressionType.Convert)
                    memberExpr = unaryExpr.Operand as MemberExpression;
            }

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property)
                fields.Add(memberExpr.Member.Name);

            return fields.ToArray();
        }

        public static Type GetPropertyBaseType(this Type property)
        {
            if (property.IsGenericType)
            {
                property = property.GetGenericArguments()[0];
            }
            return property;
        }
    }
}
