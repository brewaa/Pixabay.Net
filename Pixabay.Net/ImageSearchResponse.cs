using System.Collections.ObjectModel;

namespace Pixabay.Net
{
    public class ImageSearchResponse
    {
        public int total { get; set; }
        public int totalHits { get; set; }
        public Collection<ImageSearchHit> hits { get; set; }

        public ImageSearchResponse()
        {
            hits = new Collection<ImageSearchHit>();
        }
    }
}
