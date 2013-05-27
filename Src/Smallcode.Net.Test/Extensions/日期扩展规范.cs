using System;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("日期", "扩展")]
    public class 日期扩展规范
    {
        public It 能转换为10位Unix时间戳 = () => DateTime.Now.ToUnixTimeString().ShouldMatch(s => s.Length == 10);
        public It 能转换为大于10位Unix时间戳 = () => DateTime.Now.ToUnixTimeString(13).ShouldMatch(s => s.Length == 13);
        public It 能转换为小于10位Unix时间戳 = () => DateTime.Now.ToUnixTimeString(8).ShouldMatch(s => s.Length == 8);
    }
}