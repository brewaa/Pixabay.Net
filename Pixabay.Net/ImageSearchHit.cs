using Newtonsoft.Json;

namespace Pixabay.Net
{
    public class ImageSearchHit
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pageUrl")]
        public string PageURL { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("previewURL")]
        public string PreviewURL { get; set; }

        [JsonProperty("previewWidth")]
        public int PreviewWidth { get; set; }

        [JsonProperty("previewHeight")]
        public int PreviewHeight { get; set; }

        [JsonProperty("webformatURL")]
        public string WebformatURL { get; set; }

        [JsonProperty("webformatWidth")]
        public int WebformatWidth { get; set; }

        [JsonProperty("webformatHeight")]
        public int WebformatHeight { get; set; }

        [JsonProperty("imageWidth")]
        public int ImageWidth { get; set; }

        [JsonProperty("imageHeight")]
        public int ImageHeight { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("downloads")]
        public int Downloads { get; set; }

        [JsonProperty("favorites")]
        public int Favorites { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("comments")]
        public int Comments { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("userImageURL")]
        public string UserImageURL { get; set; }

        #endregion

        #region Properties - High Resolution

        [JsonProperty("id_hash")]
        public string IdHash { get; set; }

        [JsonProperty("largeImageURL")]
        public string LargeImageURL { get; set; }

        [JsonProperty("fullHDURL")]
        public string FullHDURL { get; set; }

        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }

        [JsonProperty("vectorURL")]
        public string VectorURL { get; set; }

        #endregion
    }
}
