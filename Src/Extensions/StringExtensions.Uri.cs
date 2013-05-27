using System;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     Uri生成
    /// </summary>
    public static partial class StringExtensions
    {
        public static string MakeAbsoluteUri(this string relativeUri, Uri baseUri)
        {
            return relativeUri.StartsWith("/") ? new Uri(baseUri, relativeUri).AbsoluteUri : relativeUri;
        }

        public static string MakeAbsoluteUri(this string relativeUri, string baseUri)
        {
            return relativeUri.StartsWith("/") ? new Uri(new Uri(baseUri), relativeUri).AbsoluteUri : relativeUri;
        }
    }
}