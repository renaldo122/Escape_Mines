using System;

namespace Escape_Mines.Common.Exceptions
{

    /// <summary>
    /// Represents errors that occur during application execution
    /// </summary>
    [Serializable]
    public class EscapeMinesException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the Exception class.
        /// </summary>
        public EscapeMinesException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public EscapeMinesException(string message)
                : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="messageFormat">The exception message format.</param>
        /// <param name="args">The exception message arguments.</param>
        public EscapeMinesException(string messageFormat, params object[] args)
                : base(string.Format(messageFormat, args))
        {
        }
    }
}
