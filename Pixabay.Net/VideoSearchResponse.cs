using System.Collections.ObjectModel;

namespace Pixabay.Net
{
    public class VideoSearchResponse
    {
        public Collection<VideoSearchHit> Hits { get; set; }
        public int Total { get; set; }
        public int TotalHits { get; set; }

        public VideoSearchResponse()
        {
            Hits = new Collection<VideoSearchHit>();
        }
    }
}
