using Newtonsoft.Json;
using System.Reflection;

namespace Pixabay.Net.Helpers
{
    /// <summary>
    /// Helper methods
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// Returns a query string with object PropertyName/Value or JsonPropertyAttribute PropertyName/Value as query string parameters.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToQueryString(object obj)
        {
            var result = string.Empty;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var propName = prop.Name;
                var val = prop.GetValue(obj);
                if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                {
                    foreach (var attr in prop.GetCustomAttributes(true))
                    {
                        JsonPropertyAttribute jpa = attr as JsonPropertyAttribute;
                        if (jpa != null)
                        {
                            propName = jpa.PropertyName;
                        }
                    }
                    result += $"&{propName}={val}";
                }
            }

            result = result
            .TrimStart(new char[] { '&' })
            .Insert(0, "?");

            return result;
        }
    }
}
