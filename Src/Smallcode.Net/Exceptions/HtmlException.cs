using System;

namespace Smallcode.Net.Exceptions
{
    public class HtmlException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlException"/> class.
        /// </summary>
        public HtmlException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlException"/> class with 
        /// a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public HtmlException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlException"/> class with
        /// a specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or <see langword="null"/> if no inner exception is specified.</param>
        public HtmlException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
