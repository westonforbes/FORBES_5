using System;
using System.Collections.Generic;
using FORBES_5.ASCII_RENDER_NAMESPACE;
namespace ASCII_RENDER_TEST_APPLICATION
{
    class Program
    {
        static int Main(string[] args) //Debug setup of this test applicatrion
        {
            string FILEPATH = args[0]; //Get the filepath. No checks in place because this is a test application.
            var FRAME_SET = new List<char[,]>(); //Where the ASCII art will be stored.
            try { FRAME_SET = ASCII_RENDER.PROCESS_IMAGE(FILEPATH, 100, 100); } //Try to process the image.
            catch (Exception) { return -1; } //If anything failed, exit with error code.
            return ASCII_RENDER.RENDER_IMAGE(FRAME_SET, 50, 10); //Render the image and exit with whatever code the function generates.
        }
    }
}
