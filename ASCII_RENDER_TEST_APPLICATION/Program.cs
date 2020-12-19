using System;
using System.Collections.Generic;
using FORBES_5.ASCII_RENDER_NAMESPACE;
using FORBES_5.LOGGER_NAMESPACE;
namespace ASCII_RENDER_TEST_APPLICATION
{
    class Program
    {
        static int Main(string[] args) //Debug setup of this test applicatrion
        {
            LOGGER.METHOD_ENTER();
            string FILEPATH = args[0]; //Get the filepath. No checks in place because this is a test application.
            var FRAME_SET = new List<char[,]>(); //Where the ASCII art will be stored.
            try { FRAME_SET = ASCII_RENDER.PROCESS_IMAGE(FILEPATH, 30, 30); } //Try to process the image.
            catch (Exception EX) //If anything failed, catch the exception.
            {
                LOGGER.EXCEPTION(EX.Message); //Write the exception to the log.
                LOGGER.METHOD_EXIT_FAIL(); //Write the failed exit to the log.
                return -1; 
            } 
            int RETURN_CODE = ASCII_RENDER.RENDER_IMAGE(FRAME_SET, 10, 10); //Render the image.
            LOGGER.LOG(string.Format("Return code: {0}", RETURN_CODE));
            LOGGER.METHOD_EXIT_SUCCESS();
            LOGGER.OPEN_LOG();
            return RETURN_CODE; //Exit with the RENDER_IMAGE return code.
        }
    }
}
