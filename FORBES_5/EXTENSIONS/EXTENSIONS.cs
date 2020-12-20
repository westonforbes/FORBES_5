using System;
using FORBES_5.LOGGER_NAMESPACE;

namespace FORBES_5.EXTENSIONS_NAMESPACE
{
    /// <summary>
    /// Custom extensions for strings.
    /// </summary>
    public static class STRING_EXTENSIONS
    {
        /// <summary>
        /// Turn on this property to activate the logger.
        /// </summary>
        public static bool LOGGER_ON { get; set; } = false;
        /// <summary>
        /// This function will truncate and pad any string to length.
        /// </summary>
        /// <param name="VALUE">The string to truncate and pad.</param>
        /// <param name="LENGTH">The number of characters to adjust to.</param>
        /// <param name ="PAD_CHARACTER">A character you wish to pad the string with. Defaults to a space character.</param>
        /// <returns>The truncated and padded string.</returns>
        public static string TRUNCATE_AND_PAD(this string VALUE, int LENGTH, char PAD_CHARACTER = ' ')
        {
            if (LOGGER_ON) { LOGGER.METHOD_ENTER(); }
            VALUE = VALUE.PadRight(LENGTH, PAD_CHARACTER); //Pad string.
            VALUE = VALUE.Substring(0, LENGTH); //Truncate string.
            if (LOGGER_ON) { LOGGER.METHOD_EXIT(); }
            return VALUE; //Return string.
        }

        /// <summary>
        /// This will center a string inside a string of a longer length. Note that this has not been protected from every case.
        /// It is wrapped in a try-catch but be sure to test your own edge cases and such because this is a pretty basic centering tool, mostly for use on things like console table headers.
        /// </summary>
        /// <param name="VALUE">The string to center.</param>
        /// <param name="LENGTH">How many characters to center it in.</param>
        /// <param name="PAD_CHARACTER">The character to pad with, defaults to space.</param>
        /// <returns></returns>
        public static string CENTER(this string VALUE, int LENGTH, char PAD_CHARACTER)
        {
            if (LOGGER_ON) { LOGGER.METHOD_ENTER(); }
            try
            {
                int VALUE_HALF_COUNT = VALUE.Length / 2;
                int LENGTH_HALF_COUNT = LENGTH / 2;
                int START_LOCATION = LENGTH_HALF_COUNT - VALUE_HALF_COUNT; //Figure out where we need to start the new string.
                string OUTPUT = null;
                for (int i = 0; i < START_LOCATION; i++) { OUTPUT += PAD_CHARACTER; } //Loop through to pad the left side.
                OUTPUT += VALUE; //Add the original string.
                if (VALUE.Length % 2 != 0) { START_LOCATION -= 1; } //Determine if there is a odd amount of characters in the string. 
                                                                    //If there are, subtract one to help keep it centered.
                for (int i = 0; i < START_LOCATION; i++) { OUTPUT += PAD_CHARACTER; } //Loop through to pad the right side.
                if (LOGGER_ON) { LOGGER.METHOD_EXIT_SUCCESS(); }
                return OUTPUT;
            }
            catch(Exception EX)
            {
                if(LOGGER_ON) { LOGGER.EXCEPTION(EX.Message); }
                if (LOGGER_ON) { LOGGER.METHOD_EXIT_FAIL(); }
                return VALUE;
            }

        }
    }
}
