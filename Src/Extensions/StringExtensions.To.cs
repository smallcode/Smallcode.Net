using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     类型转换
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     转换为数字
        /// </summary>
        public static int ToInt(this string text)
        {
            return Convert.ToInt32(text);
        }

        /// <summary>
        ///     将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="value">字符串格式的日期</param>
        /// <returns>日期</returns>
        public static DateTime ToDateTime(this string value)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0)).AddSeconds(Convert.ToDouble(value.Substring(0, 10)));
        }

        /// <summary>
        ///     转换为Html
        /// </summary>
        public static Html ToHtml(this string html)
        {
            return Html.Parse(html);
        }

        /// <summary>
        ///     转换为Json，再转换为相应的类型
        /// </summary>
        public static JObject ToJObject(this string json)
        {
            return JObject.Parse(json);
        }

        /// <summary>
        ///     转换为Json，再转换为相应的类型
        /// </summary>
        public static T ToJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        ///     截取Json字符串
        /// </summary>
        public static string ToJsonString(this string input)
        {
            return input.StartsWith("{") ? input : input.CutString("{", "}", true, true);
        }

        /// <summary>
        ///     转换为字典
        /// </summary>
        /// <param name="input">
        ///     要转换的字符串
        ///     <example>格式如：a=1&b=2</example>
        /// </param>
        /// <returns>字典</returns>
        public static IDictionary<string, string> ToDictionary(this string input)
        {
            var dic = new Dictionary<string, string>();
            var list = input.Matches(GetUrlPattern(@"(?<key>\w+)"),
                                     group =>
                                     new KeyValuePair<string, string>(group["key"].Value, group["value"].Value));
            foreach (var pair in list.Where(pair => !dic.ContainsKey(pair.Key)))
            {
                dic.Add(pair.Key, pair.Value);
            }
            return dic;
        }

    }
}