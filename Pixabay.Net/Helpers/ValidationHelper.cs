using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Pixabay.Net.Helpers
{
    /// <summary>
    /// Helper methods
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Checks if a boolean header value exists in HttpResponse.Headers
        /// </summary>
        /// <param name="headers">HttpResponse.Headers</param>
        /// <param name="headerName">The name of the header to validate</param>
        /// <param name="defaultValue">The default return value if no valid header is found</param>
        /// <returns></returns>
        public static bool GetBoolean(HttpResponseHeaders headers, string headerName, bool defaultValue)
        {
            if (headers.TryGetValues(headerName, out IEnumerable<string> collection))
            {
                var firstValue = collection.FirstOrDefault();
                if (firstValue != null && bool.TryParse(firstValue, out bool successValue))
                {
                    return successValue;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Checks if an integer header value exists in HttpResponse.Headers
        /// </summary>
        /// <param name="headers">HttpResponse.Headers</param>
        /// <param name="headerName">The name of the header to validate</param>
        /// <param name="defaultValue">The default return value if no valid header is found</param>
        /// <returns></returns>
        public static int GetInteger(HttpResponseHeaders headers, string headerName, int defaultValue)
        {
            if (headers.TryGetValues(headerName, out IEnumerable<string> collection))
            {
                var firstValue = collection.FirstOrDefault();
                if (firstValue != null && int.TryParse(firstValue, out int successValue))
                {
                    return successValue;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Checks if a string header value exists in HttpResponse.Headers
        /// </summary>
        /// <param name="headers">HttpResponse.Headers</param>
        /// <param name="headerName">The name of the header to validate</param>
        /// <param name="defaultValue">The default return value if no valid header is found</param>
        /// <returns></returns>
        public static string GetString(HttpResponseHeaders headers, string headerName, string defaultValue)
        {
            if (headers.TryGetValues(headerName, out IEnumerable<string> collection))
            {
                if (!string.IsNullOrWhiteSpace(collection.FirstOrDefault()))
                {
                    return collection.FirstOrDefault();
                }
            }

            return defaultValue;
        }
    }
}
