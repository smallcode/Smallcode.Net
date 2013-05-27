using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Smallcode.Net.Extensions
{
    public static class CookieContainerExtensions
    {
        /// <summary>
        ///     获取CookieContainer中对象
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IList<Cookie> GetAllCookies(this CookieContainer container)
        {
            if (container == null)
            {
                return new List<Cookie>();
            }
            var lstCookies = new List<Cookie>();

            var table =
                (Hashtable)
                container.GetType()
                         .InvokeMember("m_domainTable",
                                       BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null,
                                       container, new object[] {});

            foreach (var pathList in table.Values)
            {
                var lstCookieCol =
                    (SortedList)
                    pathList.GetType()
                            .InvokeMember("m_list",
                                          BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null,
                                          pathList, new object[] {});
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }

            return lstCookies;
        }
    }
}