using System;
using Machine.Specifications;

namespace Smallcode.Net.Test.FormParsers
{
    [Subject("表单解析"), Tags("表单", "解析")]
    public class 当源代码中没有含Form标签时 : 表单规范
    {
        public static Exception Exception;

        public Because Of = () =>
            {
                Exception = Catch.Exception(() => new FormParser(string.Empty));
            };

        public It 必须抛出异常 = () =>
                           Exception.ShouldBeOfType<Exception>();
    }
}