using Newtonsoft.Json;

namespace Pixabay.Net
{
    public class Video
    {
        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }
    }
}