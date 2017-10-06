using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Pixabay.Net
{
    public class VideoSearchResponse
    {
        [JsonProperty("hits")]
        public Collection<VideoSearchHit> Hits { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("totalHits")]
        public int TotalHits { get; set; }

        public VideoSearchResponse()
        {
            Hits = new Collection<VideoSearchHit>();
        }
    }
}
