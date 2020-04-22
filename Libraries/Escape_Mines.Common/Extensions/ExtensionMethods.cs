using Escape_Mines.Common.Common;
using Escape_Mines.Common.Exceptions;

namespace Escape_Mines.Common.Extensions
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// Convert string to Int32 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="throwExceptionIfFailed"></param>
        /// <returns></returns>
        public static int ToInt32(this string input, bool throwExceptionIfFailed = Constants.throwExceptionIfFailed)
        {
            int result;
            var valid = int.TryParse(input, out result);
            if (!valid)
                if (throwExceptionIfFailed)
                    throw new EscapeMinesException(string.Format("'{0}' cannot be converted as int", input));
            return result;
        }
    }
}
