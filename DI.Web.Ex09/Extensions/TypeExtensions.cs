using System;

namespace DI.Web.Ex09.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Checks if a type has an attribute
        /// </summary>
        /// <param name="t"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type t, Type attribute)
        {
            var results = t.GetCustomAttributes(attribute, true);
            return results.Length > 0;
        }
    }
}