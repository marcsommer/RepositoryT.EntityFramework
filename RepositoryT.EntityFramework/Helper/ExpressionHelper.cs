using System;
using System.Linq.Expressions;

namespace RepositoryT.EntityFramework.Helper
{
    public static class ExpressionHelper
    {
        public static string GetPropertyName(Expression<Func<object, object>> property)
        {
            var expr = (property.Body);
            string propertyName = string.Empty;

            if (expr is UnaryExpression)
            {
                propertyName =
                    (((MemberExpression)
                      (((UnaryExpression)
                        (property.Body)).Operand)).Member).Name;
            }
            else if (expr is MemberExpression)
            {
                propertyName = (((MemberExpression)
                           (property.Body)).Member).Name;
            }

            return propertyName;
        }

    }
}