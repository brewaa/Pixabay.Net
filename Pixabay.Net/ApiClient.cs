using Pixabay.Net.Helpers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pixabay.Net
{
    /// <summary>
    /// Provides an HttpClient
    /// </summary>
    public class ApiClient
    {
        #region Properties

        /// <summary>
        /// Get or Set the HttpClient used for all requests
        /// </summary>
        public HttpClient Client { get; set; }
        /// <summary>
        /// Get or Set the RateLimit allowed by the API endpoint. Set RateLimit to zero for NO LIMIT
        /// </summary>
        public int RateLimit { get; set; }
        /// <summary>
        /// Get the RateLimitRemaining provided as an HttpHeader from an HttpResponseMessage
        /// </summary>
        public int RateLimitRemaining { get; private set; }
        /// <summary>
        /// Get the RateLimitReset provided as an HttpHeader from an HttpResponseMessage
        /// </summary>
        public int RateLimitReset { get; private set; }
        /// <summary>
        /// Returns the URI of the last query executed
        /// </summary>
        public string UriLastQuery { get; private set; }

        #endregion

        #region Constructor

        public ApiClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            RateLimit = 5000;
            RateLimitRemaining = RateLimit;
            RateLimitReset = 3600;
            UriLastQuery = string.Empty;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calls HttpClient.GetAsync and returns an HttpResponseMessage
        /// </summary>
        /// <param name="uri">The URi to send the GET request to</param>
        /// <param name="cache">A MemoryCache object</param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get(Uri uri)
        {
            var response = await Client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                UriLastQuery = uri.LocalPath;
                RateLimit = ValidationHelper.GetInteger(response.Headers, "X-RateLimit-Limit", RateLimit);
                RateLimitRemaining = ValidationHelper.GetInteger(response.Headers, "X-RateLimit-Remaining", RateLimitRemaining);
                RateLimitReset = ValidationHelper.GetInteger(response.Headers, "X-RateLimit-Reset", RateLimitReset);
            }

            return response;
        }

        #endregion
    }
}
