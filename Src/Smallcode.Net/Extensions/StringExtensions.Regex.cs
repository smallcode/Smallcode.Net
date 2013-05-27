using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Smallcode.Net.Extensions
{
    /// <summary>
    ///     字符串正则匹配
    /// </summary>
    public static partial class StringExtensions
    {
        ///// <summary>
        /////     匹配第一项
        ///// </summary>
        ///// <param name="input">要匹配的内容</param>
        ///// <param name="pattern">正则规则</param>
        ///// <param name="defaultValue">匹配失败后所返回的默认值</param>
        ///// <param name="groupIndex">Group中的索引,默认为第一项</param>
        ///// <param name="options">正则选项</param>
        ///// <returns>匹配到的第一项</returns>
        //public static string MatchFirst(this string input, string pattern, string defaultValue = "", int groupIndex = 1,
        //                                RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled)
        //{
        //    var match = Regex.Match(input, pattern, options);
        //    return match.Success ? match.Groups[groupIndex].Value : defaultValue;
        //}

        /// <summary>
        ///     是否匹配
        /// </summary>
        /// <param name="input">要匹配的内容</param>
        /// <param name="pattern">正则规则</param>
        /// <param name="successCallback">匹配成功时的回调函数</param>
        /// <param name="failCallback">匹配失败时的回调函数</param>
        /// <param name="options">正则选项</param>
        /// <returns>是否匹配</returns>
        public static Match Match(this string input, string pattern, Action<GroupCollection> successCallback = null,
                                  Action failCallback = null,
                                  RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Compiled)
        {
            var match = Regex.Match(input, pattern, options);
            if (successCallback != null && match.Success)
                successCallback(match.Groups);
            else if (failCallback != null)
                failCallback();
            return match;
        }

        /// <summary>
        ///     匹配多项
        /// </summary>
        /// <typeparam name="TReturn">返回值的类型</typeparam>
        /// <param name="input">要匹配的内容</param>
        /// <param name="pattern">正则规则</param>
        /// <param name="getValue">获取值的函数</param>
        /// <param name="options">正则选项</param>
        /// <returns>匹配到的值的列表</returns>
        public static IList<TReturn> Matches<TReturn>(this string input, string pattern,
                                                      Func<GroupCollection, TReturn> getValue,
                                                      RegexOptions options =
                                                          RegexOptions.IgnoreCase | RegexOptions.Compiled)
        {
            var matches = Regex.Matches(input, pattern, options);
            var list = new List<TReturn>();
            foreach (Match match in matches)
            {
                var value = getValue(match.Groups);
                if (!list.Contains(value)) list.Add(value);
            }
            return list;
        }
    }
}