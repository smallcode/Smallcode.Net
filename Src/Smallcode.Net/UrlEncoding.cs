namespace Smallcode.Net
{
    /// <summary>
    /// Url编码类型，它的数值类型代表Encoding的codepage属性，GBK和GB2312的codepage是相同的
    /// </summary>
    public enum UrlEncoding
    {
        NONE = 0,
        UTF8 = 65001,
        GB2312 = 936
    }
}