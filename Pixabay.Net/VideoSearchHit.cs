using Newtonsoft.Json;

namespace Pixabay.Net
{
    public class VideoSearchHit
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("pageURL")]
        public string PageURL { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("picture_id")]
        public string PictureId { get; set; }

        [JsonProperty("videos")]
        public Videos Videos { get; set; }

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
    }
}
