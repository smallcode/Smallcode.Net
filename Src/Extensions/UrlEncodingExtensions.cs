using System.Text;

namespace Smallcode.Net.Extensions
{
    public static class UrlEncodingExtensions
    {
        public static Encoding ToEncoding(this UrlEncoding encoding)
        {
            switch (encoding)
            {
                case UrlEncoding.NONE:
                    return Encoding.Default;
                case UrlEncoding.UTF8:
                case UrlEncoding.GB2312:
                    return Encoding.GetEncoding((int)encoding);
                default:
                    return Encoding.Default;
            }
        }
    }
}