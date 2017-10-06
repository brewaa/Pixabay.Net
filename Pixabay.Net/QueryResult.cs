using System;
using System.Net.Http;

namespace Pixabay.Net
{
    public class QueryResult
    {
        #region Properties

        private DateTime _finishTime;

        public DateTime FinishTime
        {
            get { return _finishTime; }
            set { _finishTime = value; }
        }

        private ImageSearchParameters _imageSearchParameters;

        public ImageSearchParameters ImageSearchParameters
        {
            get { return _imageSearchParameters; }
            set { _imageSearchParameters = value; }
        }

        private ImageSearchResponse _imageSearchResponse;

        public ImageSearchResponse ImageSearchResponse
        {
            get { return _imageSearchResponse; }
            set { _imageSearchResponse = value; }
        }

        private bool _isCached;

        public bool IsCached
        {
            get { return _isCached; }
            set { _isCached = value; }
        }

        private object _parameters;

        public object Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        private QueryTypeEnum _queryType;

        public QueryTypeEnum QueryType
        {
            get { return _queryType; }
            set { _queryType = value; }
        }

        private string _rawJson;

        public string RawJson
        {
            get { return _rawJson; }
            set { _rawJson = value; }
        }

        private HttpResponseMessage _response;

        public HttpResponseMessage Response
        {
            get { return _response; }
            set { _response = value; }
        }

        private object _responseObject;

        public object ResponseObject
        {
            get { return _responseObject; }
            set { _responseObject = value; }
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private VideoSearchParameters _videoSearchParameters;

        public VideoSearchParameters VideoSearchParameters
        {
            get { return _videoSearchParameters; }
            set { _videoSearchParameters = value; }
        }

        private VideoSearchResponse _videoSearchResponse;

        public VideoSearchResponse VideoSearchResponse
        {
            get { return _videoSearchResponse; }
            set { _videoSearchResponse = value; }
        }

        #endregion

        #region Constructor

        public QueryResult()
        {
            _imageSearchParameters = new ImageSearchParameters();
            _imageSearchResponse = new ImageSearchResponse();
            _isCached = false;
            _parameters = null;
            _queryType = QueryTypeEnum.image;
            _rawJson = string.Empty;
            _response = new HttpResponseMessage();
            _responseObject = null;
            _startTime = DateTime.UtcNow;
            _url = string.Empty;
            _videoSearchParameters = new VideoSearchParameters();
            _videoSearchResponse = new VideoSearchResponse();
        }

        #endregion
    }
}
