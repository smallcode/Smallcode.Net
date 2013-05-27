using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Smallcode.Net.Extensions;

namespace Smallcode.Net
{
    public class FormData : Dictionary<string, string>
    {
        public FormData()
        {
            _encoding = UrlEncoding.NONE;
        }

        private UrlEncoding _encoding;

        public FormData Encoding(UrlEncoding encoding)
        {
            _encoding = encoding;
            return this;
        }

        private string Encode(string value)
        {
            switch (_encoding)
            {
                case UrlEncoding.NONE:
                    return value;
                case UrlEncoding.UTF8:
                    return Uri.EscapeDataString(value);
                case UrlEncoding.GB2312:
                    return value.EscapeDataStringBy(_encoding);
                default:
                    return value;
            }
        }

        public override string ToString()
        {
            return string.Join("&", this.Select(pair => string.Format("{0}{2}{1}", pair.Key, Encode(pair.Value), pair.Key.IsNullOrWhiteSpace() ? string.Empty : "=")));
        }

        public FormData Set(string key, string value)
        {
            base[key] = value;
            return this;
        }

        public FormData Set(string key, int value)
        {
            return Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public FormData Set(string key, long value)
        {
            return Set(key, value.ToString(CultureInfo.InvariantCulture));
        }

        private FormData Set(string key, bool value)
        {
            return Set(key, value ? 1 : 0);
        }

        public FormData SetEmpty(string key)
        {
            return Set(key, string.Empty);
        }

        public FormData SetZero(string key)
        {
            return Set(key, 0);
        }

        public FormData SetTrue(string key)
        {
            return Set(key, true);
        }

        public FormData SetFalse(string key)
        {
            return Set(key, false);
        }

        public FormData SetRandomInteger(string key, int length)
        {
            return Set(key, new Random().NextIntString(length));
        }

        public FormData SetRandomFloat(string key, int length)
        {
            return Set(key, new Random().NextDoubleString(length));
        }

        public FormData SetUnixTimestamp(string key, int length, string prefix = "")
        {
            return Set(key, prefix + DateTime.Now.ToUnixTimeString(length));
        }


    }
}