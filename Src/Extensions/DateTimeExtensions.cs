using System;
using System.Globalization;

namespace Smallcode.Net.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     转换为Unix时间戳（从1970/1/1起至今的秒数）
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="length">时间戳长度</param>
        /// <returns>Unix时间戳</returns>
        public static string ToUnixTimeString(this DateTime dateTime, int length = 10)
        {
            var now = (dateTime - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds;
            return length == 10
                       ? Math.Floor(now).ToString(CultureInfo.InvariantCulture)
                       : (length > 10
                              ? Math.Floor(now * Math.Pow(10, length - 10)).ToString(CultureInfo.InvariantCulture)
                              : Math.Floor(now).ToString(CultureInfo.InvariantCulture).Substring(0, length));
        }
    }
}