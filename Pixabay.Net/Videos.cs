using Newtonsoft.Json;

namespace Pixabay.Net
{
    public class Videos
    {
        [JsonProperty("large")]
        public Video Large { get; set; }

        [JsonProperty("medium")]
        public Video Medium { get; set; }

        [JsonProperty("small")]
        public Video Small { get; set; }

    }
}
