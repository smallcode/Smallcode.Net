using System;
using System.Net;
using Smallcode.Net.Extensions;

namespace Smallcode.Net
{
    public class Url
    {
        public Url(string urlString)
        {
            _urlString = urlString;
            _data = new FormData();
        }

        public Url(string urlString, params object[] args)
            : this(args.Length > 0 ? string.Format(urlString, args) : urlString)
        {

        }

        public Url(string urlString, object arg0)
            : this(string.Format(urlString, arg0))
        {

        }

        public Url(string urlString, object arg0, object arg1)
            : this(string.Format(urlString, arg0, arg1))
        {

        }

        public Url(string urlString, object arg0, object arg1, object arg2)
            : this(string.Format(urlString, arg0, arg1, arg2))
        {

        }

        private string _urlString;
        private readonly FormData _data;

        public Uri Uri
        {
            get
            {
                return new Uri(ToString());
            }
        }

        public override string ToString()
        {
            return _data.Count == 0 ? _urlString : string.Format("{0}{2}{1}", _urlString, _data, _urlString.Contains("?") ? "&" : "?");
        }

        public Url Encoding(UrlEncoding encoding)
        {
            _data.Encoding(encoding);
            return this;
        }

        public Url Combine(string path)
        {
            if (_urlString.EndsWith("/") && path.StartsWith("/"))
                path = path.TrimStart('/');
            _urlString = _urlString + path;
            return this;
        }

        public Url Append(string key, string value)
        {
            _data.Set(key, value);
            return this;
        }

        public Url Append(string key, int value)
        {
            _data.Set(key, value);
            return this;
        }

        public Url Append(string key, long value)
        {
            _data.Set(key, value);
            return this;
        }

        public Url AppendEmpty(string key)
        {
            _data.SetEmpty(key);
            return this;
        }

        public Url AppendZero(string key)
        {
            _data.SetZero(key);
            return this;
        }

        public Url AppendTrue(string key)
        {
            _data.SetTrue(key);
            return this;
        }

        public Url AppendFalse(string key)
        {
            _data.SetFalse(key);
            return this;
        }

        public Url AppendRandomInteger(string key, int length)
        {
            _data.SetRandomInteger(key, length);
            return this;
        }

        public Url AppendRandomFloat(string key, int length)
        {
            _data.SetRandomFloat(key, length);
            return this;
        }

        public Url AppendUnixTimestamp(string key, int length, string prefix = "")
        {
            _data.SetUnixTimestamp(key, length, prefix);
            return this;
        }

        public HttpWebRequest CreateRequest()
        {
            return Uri.CreateRequest();
        }
    }
}