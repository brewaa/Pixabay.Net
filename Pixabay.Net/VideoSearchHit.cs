namespace Pixabay.Net
{
    public class VideoSearchHit
    {
        #region Properties

        public int id { get; set; }
        public string pageURL { get; set; }
        public string type { get; set; }
        public string tags { get; set; }
        public int duration { get; set; }
        public string picture_id { get; set; }
        public Videos videos { get; set; }
        public int views { get; set; }
        public int downloads { get; set; }
        public int favorites { get; set; }
        public int likes { get; set; }
        public int comments { get; set; }
        public int user_id { get; set; }
        public string user { get; set; }
        public string userImageURL { get; set; }

        #endregion
    }
}
