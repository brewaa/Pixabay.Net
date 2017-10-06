using Newtonsoft.Json;
using System.Net;

namespace Pixabay.Net
{
    public class ImageSearchParameters
    {
        #region Properties

        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("q")]
        public string Query { get; set; }
        [JsonProperty("lang")]
        public LanguageCodeEnum LanguageCode { get; set; }
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("response_group")]
        public ResponseGroupEnum ResponseGroup { get; set; }
        [JsonProperty("image_type")]
        public ImageTypeEnum ImageType { get; set; }
        [JsonProperty("orientation")]
        public OrientationEnum Orientation { get; set; }
        [JsonProperty("category")]
        public CategoryEnum Category { get; set; }
        [JsonProperty("min_width")]
        public int MinWidth { get; set; }
        [JsonProperty("min_height")]
        public int MinHeight { get; set; }
        [JsonProperty("editors_choice")]
        public bool EditorsChoice { get; set; }
        [JsonProperty("safesearch")]
        public bool SafeSearch { get; set; }
        [JsonProperty("order")]
        public OrderEnum Order { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        [JsonProperty("callback")]
        public string CallBack { get; set; }
        [JsonProperty("pretty")]
        public bool Pretty { get; set; }

        #endregion

        #region Constructor

        public ImageSearchParameters()
        {
            Key = string.Empty;
            Query = string.Empty;
            LanguageCode = LanguageCodeEnum.en;
            ID = string.Empty;
            ResponseGroup = ResponseGroupEnum.image_details;
            ImageType = ImageTypeEnum.all;
            Orientation = OrientationEnum.all;
            Category = CategoryEnum.backgrounds;
            MinWidth = 0;
            MinHeight = 0;
            EditorsChoice = false;
            SafeSearch = false;
            Order = OrderEnum.popular;
            Page = 1;
            PerPage = 20;
            CallBack = string.Empty;
            Pretty = false;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Validate required properties and set default values
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return IsValid(this);
        }

        /// <summary>
        /// Validate required properties and set default values
        /// </summary>
        /// <returns></returns>
        private bool IsValid(ImageSearchParameters parameters)
        {
            if (string.IsNullOrWhiteSpace(parameters.Key))
            {
                return false;
            }

            if (parameters.Query.Length > 100)
            {
                parameters.Query = parameters.Query.Substring(0, 100);
            }

            parameters.Query = WebUtility.UrlEncode(parameters.Query.Trim());

            if (parameters.Page == 0)
            {
                parameters.Page = 1;
            }

            if (parameters.PerPage < 3 || parameters.PerPage > 200)
            {
                parameters.PerPage = 20;
            }

            return true;
        }

        #endregion
    }
}
