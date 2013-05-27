using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Smallcode.Net
{
    public class By
    {
        private Func<Html, Html> _findElementMethod;
        private Func<Html, ReadOnlyCollection<Html>> _findElementsMethod;

        /// <summary>
        /// Gets a mechanism to find elements by their ID.
        /// </summary>
        /// <param name="idToFind">The ID to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By Id(string idToFind)
        {
            if (idToFind == null)
            {
                throw new ArgumentNullException("idToFind", "Cannot find elements with a null id attribute.");
            }

            var by = new By();
            by._findElementMethod = context => context.FindElementById(idToFind);
            by._findElementsMethod = context => context.FindElementsById(idToFind);
            return by;
        }


        /// <summary>
        /// Gets a mechanism to find elements by their link text.
        /// </summary>
        /// <param name="linkTextToFind">The link text to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By LinkText(string linkTextToFind)
        {
            if (linkTextToFind == null)
            {
                throw new ArgumentNullException("linkTextToFind", "Cannot find elements when link text is null.");
            }

            var by = new By();
            by._findElementMethod =
                context => context.FindElementByLinkText(linkTextToFind);
            by._findElementsMethod =
                context => context.FindElementsByLinkText(linkTextToFind);
            return by;
        }

        ///// <summary>
        ///// Gets a mechanism to find elements by their name.
        ///// </summary>
        ///// <param name="nameToFind">The name to find.</param>
        ///// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        //public static By Name(string nameToFind)
        //{
        //    if (nameToFind == null)
        //    {
        //        throw new ArgumentNullException("nameToFind", "Cannot find elements when name text is null.");
        //    }

        //    var by = new By();
        //    by._findElementMethod = context => context.FindElementByName(nameToFind);
        //    by._findElementsMethod = context => context.FindElementsByName(nameToFind);

        //    return by;
        //}

        /// <summary>
        /// Gets a mechanism to find elements by an XPath query.
        /// </summary>
        /// <param name="xpathToFind">The XPath query to use.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By XPath(string xpathToFind)
        {
            if (xpathToFind == null)
            {
                throw new ArgumentNullException("xpathToFind", "Cannot find elements when the XPath expression is null.");
            }

            var by = new By();
            by._findElementMethod = context => context.FindElementByXPath(xpathToFind);
            by._findElementsMethod =
                context => context.FindElementsByXPath(xpathToFind);
            return by;
        }

        /// <summary>
        /// Gets a mechanism to find elements by their CSS class.
        /// </summary>
        /// <param name="classNameToFind">The CSS class to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        /// <remarks>If an element has many classes then this will match against each of them.
        /// For example if the value is "one two onone", then the following values for the 
        /// className parameter will match: "one" and "two".</remarks>
        public static By ClassName(string classNameToFind)
        {
            if (classNameToFind == null)
            {
                throw new ArgumentNullException("classNameToFind", "Cannot find elements when the class name expression is null.");
            }

            if (new Regex(".*\\s+.*").IsMatch(classNameToFind))
            {
                throw new ArgumentNullException("classNameToFind", "Compound class names are not supported. Consider searching for one class name and filtering the results.");
            }

            var by = new By();
            by._findElementMethod =
                context => context.FindElementByClassName(classNameToFind);
            by._findElementsMethod =
                context => context.FindElementsByClassName(classNameToFind);
            return by;
        }

        /// <summary>
        /// Gets a mechanism to find elements by a partial match on their link text.
        /// </summary>
        /// <param name="partialLinkTextToFind">The partial link text to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By PartialLinkText(string partialLinkTextToFind)
        {
            var by = new By();
            by._findElementMethod =
                context =>
                context.FindElementByPartialLinkText(partialLinkTextToFind);
            by._findElementsMethod =
                context =>
               context.FindElementsByPartialLinkText(partialLinkTextToFind);

            return by;
        }

        /// <summary>
        /// Gets a mechanism to find elements by their tag name.
        /// </summary>
        /// <param name="tagNameToFind">The tag name to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By TagName(string tagNameToFind)
        {
            if (tagNameToFind == null)
            {
                throw new ArgumentNullException("tagNameToFind", "Cannot find elements when name tag name is null.");
            }

            var by = new By();
            by._findElementMethod =
                context => context.FindElementByTagName(tagNameToFind);
            by._findElementsMethod =
                context => context.FindElementsByTagName(tagNameToFind);

            return by;
        }

        /// <summary>
        /// Gets a mechanism to find elements by their cascading style sheet (CSS) selector.
        /// </summary>
        /// <param name="cssSelectorToFind">The CSS selector to find.</param>
        /// <returns>A <see cref="By"/> object the driver can use to find the elements.</returns>
        public static By CssSelector(string cssSelectorToFind)
        {
            if (cssSelectorToFind == null)
            {
                throw new ArgumentNullException("cssSelectorToFind", "Cannot find elements when name CSS selector is null.");
            }

            var by = new By();
            by._findElementMethod =
                context => context.FindElementByCssSelector(cssSelectorToFind);
            by._findElementsMethod =
                context => context.FindElementsByCssSelector(cssSelectorToFind);

            return by;
        }

        /// <summary>
        /// Finds the first element matching the criteria.
        /// </summary>
        /// <param name="context">An <see cref="Smallcode.Net.Html"/> object to use to search for the elements.</param>
        /// <returns>The first matching <see cref="Smallcode.Net.Html"/> on the current context.</returns>
        public virtual Html FindElement(Html context)
        {
            return _findElementMethod(context);
        }

        /// <summary>
        /// Finds all elements matching the criteria.
        /// </summary>
        /// <param name="context">An <see cref="Smallcode.Net.Html"/> object to use to search for the elements.</param>
        /// <returns>A <see cref="ReadOnlyCollection{T}"/> of all <see cref="Smallcode.Net.Html">WebElements</see>
        /// matching the current criteria, or an empty list if nothing matches.</returns>
        public virtual ReadOnlyCollection<Html> FindElements(Html context)
        {
            return _findElementsMethod(context);
        }
    }


}
