using FORBES_5.EXTENSIONS_NAMESPACE;
using FORBES_5.LOGGER_NAMESPACE;

namespace EXTENSIONS_TEST_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
            STRING_EXTENSIONS.LOGGER_ON = true;
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("Extensions Test Application");
            TRUNCATE_AND_PAD_TEST();
            CENTER_TEST();
            LOGGER.OPEN_LOG();
            LOGGER.METHOD_EXIT();
        }

        static void TRUNCATE_AND_PAD_TEST()
        {
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("Testing TRUNCATE_AND_PAD.");
            string TEST_STRING = "Very super extremely extra grand enormous string";
            LOGGER.LOG(string.Format("Original string: {0}", TEST_STRING));
            TEST_STRING = TEST_STRING.TRUNCATE_AND_PAD(10);
            LOGGER.LOG(string.Format("Truncated string: {0}", TEST_STRING));
            TEST_STRING = "Little string";
            LOGGER.LOG(string.Format("Original string: {0}", TEST_STRING));
            TEST_STRING = TEST_STRING.TRUNCATE_AND_PAD(30, '*');
            LOGGER.LOG(string.Format("Padded string: {0}", TEST_STRING));
            LOGGER.METHOD_EXIT();
        }

        static void CENTER_TEST()
        {
            LOGGER.METHOD_ENTER();
            LOGGER.LOG("Testing CENTER.");
            string TEST_STRING = "TEST";
            TEST_STRING = TEST_STRING.CENTER(20, '*');
            LOGGER.LOG(string.Format("Centered string : {0}", TEST_STRING));
            LOGGER.METHOD_EXIT();
        }
    }

}
