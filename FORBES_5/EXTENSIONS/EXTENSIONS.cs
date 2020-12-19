using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORBES_5.EXTENSIONS_NAMESPACE
{
    /// <summary>
    /// Custom extensions for strings.
    /// </summary>
    public static class STRING_EXTENSIONS
    {
        /// <summary>
        /// This function will truncate and pad any string to length.
        /// </summary>
        /// <param name="VALUE">The string to truncate and pad.</param>
        /// <param name="LENGTH">The number of characters to adjust to.</param>
        /// <returns>The truncated and padded string.</returns>
        public static string TRUNCATE_AND_PAD(this string VALUE, int LENGTH)
        {
            VALUE = VALUE.PadRight(LENGTH,' '); //Pad string.
            VALUE = VALUE.Substring(0, LENGTH); //Truncate string.
            return VALUE; //Return string.
        }

        //public static string CENTER(this string VALUE, int LENGTH, char PAD_CHARACTER)
        //{
           // return VALUE;
        //}
    }
}
