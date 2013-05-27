using System;
using Machine.Specifications;
using Smallcode.Net.Extensions;

namespace Smallcode.Net.Test.Extensions
{
    [Tags("字符", "生成")]
    public class Random扩展规范
    {
        private enum TestEnum
        {
            Boy,
            Girl
        }
        public static Random Random;
        public Establish Content = () => Random = new Random();

        public It 必须正确生成指定长度的随即小数字符串 =
            () =>
            Random.NextDoubleString(10)
                         .ShouldMatch(
                             s =>
                             s.Substring(s.IndexOf(".", StringComparison.Ordinal) + 1).Length == 10 &&
                             s.StartsWith("0."));

        public It 必须正确生成指定长度的随机整数字符串 = () => Random.NextIntString(10).ShouldMatch(s => s.Length == 10 && s.IsNumberic());
        public It 必须正确生成指定长度的随机字母串 = () => Random.NextLetters(10).ShouldMatch(s => s.Length == 10);
        public It 必须正确生成指定长度的随机字符串 = () => Random.NextString(10).ShouldMatch(s => s.Length == 10);

        public It 能获取随机的男性姓名 = () => Random.NextChineseBoyFullname().Length.ShouldEqual(3);
        public It 能获取随机的布尔值 = () => Random.NextBool().ShouldBeOfType<bool>();
        public It 能获取随机的枚举值 = () => Random.NextEnum<TestEnum>().ShouldBeOfType<TestEnum>();

        public It 能获取随机的日期 = () => Random.NextDateTime().ShouldBeOfType<DateTime>();

        public It 能获取随机范围内的日期 = () =>
            {
                var min = DateTime.Now.AddDays(-1);
                var max = DateTime.Now;
                Random.NextDateTime(min, max).ShouldMatch(date => date > min && date < max);
            };

        public It 能获取随机生日 = () =>
            {
                var min = 20;
                var max = 30;
                var nextBirthday = Random.NextBirthday(min, max);
                nextBirthday.ShouldMatch(date => date > DateTime.Now.AddYears(-max) && date < DateTime.Now.AddYears(-min));
            };
    }
}