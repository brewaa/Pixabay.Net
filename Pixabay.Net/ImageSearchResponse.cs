using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Pixabay.Net
{
    public class ImageSearchResponse
    {
        [JsonProperty("hits")]
        public Collection<ImageSearchHit> Hits { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("totalHits")]
        public int TotalHits { get; set; }        

        public ImageSearchResponse()
        {
            Hits = new Collection<ImageSearchHit>();
        }
    }
}
