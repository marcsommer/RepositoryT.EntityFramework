using System;
using System.Linq.Expressions;
using RepositoryT.EntityFramework.Helper;

namespace RepositoryT.EntityFramework.Extensions
{
    public static class ObjectExtensions
    {
        public static T GetPropertyValue<T>(this object obj, string property)
        {
            return (T)obj.GetType().GetProperty(property).GetValue(obj, null);
        }

        public static T GetPropertyValue<T>(this object obj, Expression<Func<object, object>> property)
        {
            string propertyName = ExpressionHelper.GetPropertyName(property);
            return (T)obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
    }
}