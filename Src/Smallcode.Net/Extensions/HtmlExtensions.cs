using System.Collections.ObjectModel;
using System.Linq;
using Smallcode.Net.Exceptions;

namespace Smallcode.Net.Extensions
{
    internal static class HtmlExtensions
    {
        public static Html FirstOrNoSuchElement(this ReadOnlyCollection<Html> coll, string selectorInfo)
        {
            if (coll.Count > 0) return coll.First();
            throw new NotFoundException("No element was found for the expression: " + selectorInfo);
        }
    }
}