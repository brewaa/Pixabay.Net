using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Pixabay.Net.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Pixabay.Net
{
    public class PixabayClient
    {
        #region Properties

        private static ApiClient _apiClient;

        private int _rateLimit;

        public int RateLimit
        {
            get { return _rateLimit; }
            set { _rateLimit = value; }
        }

        private int _rateLimitRemaining;

        public int RateLimitRemaining
        {
            get { return _rateLimitRemaining; }
            set { _rateLimitRemaining = value; }
        }

        private int _rateLimitReset;

        public int RateLimitReset
        {
            get { return _rateLimitReset; }
            set { _rateLimitReset = value; }
        }

        private Uri _uriImageSearch;

        public Uri UriImageSearch
        {
            get { return _uriImageSearch; }
            set { _uriImageSearch = value; }
        }

        private string _uriLastQuery;

        public string UriLastQuery
        {
            get { return _uriLastQuery; }
            private set { _uriLastQuery = value; }
        }

        private Uri _uriVideoSearch;

        public Uri UriVideoSearch
        {
            get { return _uriVideoSearch; }
            set { _uriVideoSearch = value; }
        }

        #endregion

        #region Constructor

        public PixabayClient()
        {
            _apiClient = new ApiClient();
            _rateLimit = 5000;
            _rateLimitRemaining = _rateLimit;
            _rateLimitReset = 3600;
            _uriImageSearch = new Uri("https://pixabay.com/api/");
            _uriLastQuery = string.Empty;
            _uriVideoSearch = new Uri("https://pixabay.com/api/videos/");

            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                settings.Converters.Add(new StringEnumConverter());

                return settings;
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a URL to an image on Pixabay
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public string BuildLink(string hash)
        {
            return $"https://pixabay.com/goto/{hash}";
        }

        /// <summary>
        /// Returns the URI used to query the Pixabay Images API
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Uri BuildImageSearchUri(ImageSearchParameters parameters)
        {
            return BuildImageSearchUri(_uriImageSearch, parameters);
        }

        /// <summary>
        /// Returns the URI used to query the Pixabay Images API
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Uri BuildImageSearchUri(string url, ImageSearchParameters parameters)
        {
            return BuildImageSearchUri(new Uri(url), parameters);
        }

        /// <summary>
        /// Returns the URI used to query the Pixabay Images API
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Uri BuildImageSearchUri(Uri baseUri, ImageSearchParameters parameters)
        {
            var query = UrlHelper.ToQueryString(parameters);

            return new Uri($"{baseUri}{query}");
        }

        /// <summary>
        /// Returns the URI used to query the Pixabay Videos API
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Uri BuildVideoSearchUri(VideoSearchParameters parameters)
        {
            return BuildVideoSearchUri(_uriVideoSearch, parameters);
        }

        /// <summary>
        /// Returns the URI used to query the Pixabay Videos API
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Uri BuildVideoSearchUri(string url, VideoSearchParameters parameters)
        {
            return BuildVideoSearchUri(new Uri(url), parameters);
        }

        /// <summary>
        /// Returns the URI used to query the Pixabay Videos API
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Uri BuildVideoSearchUri(Uri baseUri, VideoSearchParameters parameters)
        {
            var query = UrlHelper.ToQueryString(parameters);

            return new Uri($"{baseUri}{query}");
        }

        /// <summary>
        /// Saves the URI content to disk
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="destinationPath"></param>
        public async Task Download(string uri, string destinationPath)
        {
            var response = await _apiClient.Client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var fileStream = File.Create(destinationPath))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }
            }
        }

        /// <summary>
        /// Saves a high resolution image to disk. Full HD scaled image with a maximum width/height of 1920px.
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public async Task DownloadHighResolutionImage(ImageSearchHit hit, string destinationPath)
        {
            await Download(hit.fullHDURL, destinationPath);
        }

        /// <summary>
        /// Saves the original image to disk. ?width? x ?height?
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public async Task DownloadImage(ImageSearchHit hit, string destinationPath)
        {
            await Download(hit.imageURL, destinationPath);
        }

        /// <summary>
        /// Saves a large image to disk. Scaled image with a maximum width/height of 1280px.
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public async Task DownloadLargeImage(ImageSearchHit hit, string destinationPath)
        {
            await Download(hit.largeImageURL, destinationPath);
        }

        /// <summary>
        /// Saves a preview image to disk. Low resolution images with a maximum width or height of 150 px (previewWidth x previewHeight).
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public async Task DownloadPreviewImage(ImageSearchHit hit, string destinationPath)
        {
            await Download(hit.previewURL, destinationPath);
        }

        /// <summary>
        /// Saves a webformat image to disk. Medium sized image with a maximum width or height of 640 px (webformatWidth x webformatHeight). URL valid for 24 hours.
        /// Replace '_640' in any webformatURL value to access other image sizes:
        /// Replace with '_180' or '_340' to get a 180 or 340 px tall version of the image, respectively. Replace with '_960' to get the image in a maximum dimension of 960 x 720 px.
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public async Task DownloadWebFormatImage(ImageSearchHit hit, string destinationPath)
        {
            await Download(hit.webformatURL, destinationPath);
        }

        /// <summary>
        /// Saves a vector image to disk. The vectorURL is omitted if unavailable.
        /// </summary>
        /// <param name="hit"></param>
        /// <param name="destinationPath"></param>
        /// <returns></returns>
        public async Task DownloadVectorImage(ImageSearchHit hit, string destinationPath)
        {
            await Download(hit.vectorURL, destinationPath);
        }

        /// <summary>
        /// Returns the filename from a URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetFileName(string url)
        {
            try
            {
                var uri = new Uri(url);
                return Path.GetFileName(uri.AbsolutePath);
            }
            catch { }

            return string.Empty;
        }

        /// <summary>
        /// Search the Pixabay API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="parameters"></param>
        /// <param name="queryType"></param>
        /// <returns></returns>
        public async Task<QueryResult> Search<T>(Uri uri, object parameters, QueryTypeEnum queryType)
        {
            var queryResult = new QueryResult();

            queryResult.Parameters = parameters;
            queryResult.QueryType = queryType;
            queryResult.StartTime = DateTime.Now;
            queryResult.Url = uri.LocalPath;

            var response = await _apiClient.Get(uri);

            queryResult.Response = response;

            if (response.IsSuccessStatusCode)
            {
                queryResult.RawJson = await response.Content.ReadAsStringAsync();
                queryResult.ResponseObject = JsonConvert.DeserializeObject<T>(queryResult.RawJson);
            }

            queryResult.FinishTime = DateTime.Now;

            return queryResult;
        }

        /// <summary>
        /// Search the Pixabay Images API
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<QueryResult> SearchImages(ImageSearchParameters parameters)
        {
            var uri = BuildImageSearchUri(parameters);

            return await Search<ImageSearchResponse>(uri, parameters, QueryTypeEnum.image);
        }
        
        /// <summary>
        /// Search the Pixabay Images API
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<QueryResult> SearchVideos(VideoSearchParameters parameters)
        {
            var uri = BuildVideoSearchUri(parameters);

            return await Search<VideoSearchResponse>(uri, parameters, QueryTypeEnum.video);
        }

        #endregion
    }
}
