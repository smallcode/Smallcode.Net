using System.Net;
using Machine.Specifications;

namespace Smallcode.Net.Test.HttpRequest
{
    public abstract class RequestSpecification
    {
        public static HttpWebRequest Request;
        public static string UriString;

        public Establish RequestContent = () => { UriString = "http://www.baidu.com/"; };
    }
}