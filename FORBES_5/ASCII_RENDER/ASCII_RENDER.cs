using System;
using System.IO;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

namespace FORBES_5.ASCII_RENDER_NAMESPACE
{
    /// <summary>
    /// This class can convert a image to ASCII art.
    /// This has been converted over from NET framework 4.7.2 where it had a System.Drawing dependency.
    /// System.Drawing has been substituted for SixLabors.ImageSharp as per the depreciation note on the System.Drawing MSDN page.
    /// MSDN page for System.Drawing: https://docs.microsoft.com/en-us/dotnet/api/system.drawing?view=dotnet-plat-ext-5.0
    /// ImageSharp github page: https://github.com/SixLabors/ImageSharp
    /// ImageSharp Documentation page: https://docs.sixlabors.com/api/index.html
    /// </summary>
    public static class ASCII_RENDER
    {
        /// <summary>
        /// This function will render ASCII animation and images to the console.
        /// </summary>
        /// <param name="FRAME_SET">The data to print, List Element = FRAME[ROW][COLUMN]</param>
        /// <param name="FRAME_DELAY">The amount of time in mS to pause after rendering each frame.</param>
        /// <param name="LOOP_COUNT">The number of times to loop the animation.</param>
        /// <returns>0 on success.</returns>
        /// <returns>1 on generic failure.</returns>
        public static int RENDER_IMAGE(List<char[,]> FRAME_SET, int FRAME_DELAY = 0, int LOOP_COUNT = 10)
        {
            try
            {
                char[,] SAMPLED_FRAME = FRAME_SET[0]; //Extract the first frame from the image so we can get some details on what was passed to us.
                int COLUMNS = SAMPLED_FRAME.GetLength(0); //Get the width of the frame (columns of pixels).
                int ROWS = SAMPLED_FRAME.GetLength(1); //Get the height of the frame (rows of pixels).
                int FRAME_COUNT = FRAME_SET.Count; //Get the amount of frames passed.
                for (int CURRENT_ITERATION = 0; CURRENT_ITERATION < LOOP_COUNT; CURRENT_ITERATION++) //Loop the animation the required amount of times...
                {

                    for (int CURRENT_FRAME = 0; CURRENT_FRAME < FRAME_COUNT; CURRENT_FRAME++) //Loop through each frame...
                    {
                        System.Threading.Thread.Sleep(FRAME_DELAY); //Add in an animation delay
                        Console.Clear(); //Before rendering a frame, clear the console.
                        SAMPLED_FRAME = FRAME_SET[CURRENT_FRAME]; //Transfer the frame over to its own variable. Its easier than querying the list on each operation.
                        for (int CURRENT_ROW = 0; CURRENT_ROW < ROWS; CURRENT_ROW++) //Loop down through each row...
                        {
                            string ROW_CHARACTERS = ""; //At the beginning of each row, clear out the variable that holds all the characters.
                            for (int CURRENT_COLUMN = 0; CURRENT_COLUMN < COLUMNS; CURRENT_COLUMN++) //Loop through each pixel in the row...
                            {
                                ROW_CHARACTERS += SAMPLED_FRAME[CURRENT_COLUMN, CURRENT_ROW]; //Add the pixel character to the string.
                            }
                            Console.WriteLine(ROW_CHARACTERS); //At the end of each row, print the data.
                        }
                    }
                }
                GC.Collect(); //Force garbage collection.
            }
            catch (Exception) { return -1; }
            return 0;
        }
        
        /// <summary>
        /// This function returns a image converted into ASCII art. This function will throw an exception up to the calling method there is a problem,
        /// so be ready to catch it before blindly marching on.
        /// </summary>
        /// <param name="FILEPATH">The location of the file.</param>
        /// <param name="RESIZE_X">Optional, new width to scale to.</param>
        /// <param name="RESIZE_Y">Optional, new height to scale to.</param>
        /// <returns>A list of character arrays. Each character array element 
        /// in the list represents a frame from the image (Animations supported).
        /// The first dimension of the array is the row number and the second dimension is the colum.
        /// List Element = FRAME[ROW][COLUMN]</returns>
        public static List<char[,]> PROCESS_IMAGE(string FILEPATH, int RESIZE_X = 0, int RESIZE_Y = 0)
        {
            List<char[,]> FRAME_LIST = new List<char[,]>();
            if (!File.Exists(FILEPATH)) //Check if the file exists.
                    throw new Exception("File does not exist"); //The file does not exist.
            try
            {                                                //Could use additional checks here to verify format and such.
                Image IMAGE = Image.Load(FILEPATH); //Load in the image.
                int FRAME_COUNT = IMAGE.Frames.Count; //Get the number of frames in the GIF.
                int X_DIM, Y_DIM;
                if (RESIZE_X != 0) //If the image is to be resized in the X direction...
                    X_DIM = RESIZE_X; //Set that as the new dimension.
                else //If its not to be resized...
                    X_DIM = IMAGE.Width; //Get the original image width.
                if (RESIZE_Y != 0) //If the image is to be resized in the X direction...
                    Y_DIM = RESIZE_Y; //Set that as the new dimension.
                else //If its not to be resized...
                    Y_DIM = IMAGE.Height; //Get the original image height.
                for (int CURRENT_FRAME = 0; CURRENT_FRAME < FRAME_COUNT; CURRENT_FRAME++) //Loop through each frame...
                {
                    Image<Rgba32> FRAME_IMAGE = (Image<Rgba32>)IMAGE.Frames.CloneFrame(CURRENT_FRAME); //Convert each frame into its own image.
                    byte[,] FRAME_BYTE_ARRAY = CONVERT_IMAGE(FRAME_IMAGE, X_DIM, Y_DIM); //Create a byte array of frame pixels.
                    char[,] FRAME_CHAR_ARRAY = CONVERT_TO_ASCII(FRAME_BYTE_ARRAY); //Convert the frame pixels to ASCII art.
                    FRAME_LIST.Add(FRAME_CHAR_ARRAY); //Add the ASCII art frame to the list.
                }
            }
            catch(Exception){throw;} //Throw any problems up to the calling method to deal with.
            GC.Collect(); //Force cleanup.
            return FRAME_LIST;
        }

        /// <summary>
        /// This function will convert a image to a luminescence byte array.
        /// </summary>
        /// <param name="IMAGE">The image to convert.</param>
        /// <param name="X_SIZE">If you want to scale the image, send the output width. Note: Both X and Y values must be sent for scaling to process.</param>
        /// <param name="Y_SIZE">If you want to scale the image, send the output height. Note: Both X and Y values must be sent for scaling to process.</param>
        /// <returns>A byte array of luminescence values.</returns>
        private static byte[,] CONVERT_IMAGE(Image<Rgba32> IMAGE, int X_SIZE = 0, int Y_SIZE = 0)
        {
            if (X_SIZE != 0 && Y_SIZE != 0) //If a new X and Y size is defined...
                IMAGE.Mutate(VAR => VAR.Resize(X_SIZE, Y_SIZE)); //Scale the bitmap.
            int WIDTH = IMAGE.Width; //Define the width.
            int HEIGHT = IMAGE.Height; //Define the height.
            byte[,] PIXEL_ARRAY = new byte[WIDTH, HEIGHT]; //Create the array that will be populated.
            //Process the array, go through each row, and process each value (across first, then down).
            for (int Y = 0; Y < HEIGHT; Y++) //Loop through each row.
            {
                for (int X = 0; X < WIDTH; X++) //Loop through each column in a row.
                {
                    Rgba32 PIXEL_COLOR = IMAGE[X, Y]; //Get the color of each pixel.
                    byte PIXEL_GRAYSCALE = (byte)((PIXEL_COLOR.R * .3) +
                                                  (PIXEL_COLOR.G * .59) +
                                                  (PIXEL_COLOR.B * .11)); //Convert to grayscale, these values are the proper proportions according to the internet.
                    PIXEL_ARRAY[X, Y] = PIXEL_GRAYSCALE; //Save the value to the array.
                }
            }
            return PIXEL_ARRAY; //Return the array.
        }

        /// <summary>
        /// This function will convert a byte array of luminescence values to ASCII representations of those values. The function has 12 shades.
        /// </summary>
        /// <param name="BYTE_ARRAY">The byte array to convert.</param>
        /// <returns>A character array of an image ready to print.</returns>
        private static char[,] CONVERT_TO_ASCII(byte[,] BYTE_ARRAY)
        {
            int WIDTH = BYTE_ARRAY.GetLength(0); //Get the width of the image.
            int HEIGHT = BYTE_ARRAY.GetLength(1); //Get the height of the image.
            char[,] CHAR_ARRAY = new char[WIDTH, HEIGHT];
            //Process the array, go through each row, and process each value (across first, then down).
            for (int Y = 0; Y < HEIGHT; Y++) //Loop through each row.
            {
                for (int X = 0; X < WIDTH; X++) //Loop through each column in a row.
                {
                    int REDUCED_BYTE_VALUE = (int)Math.Round(BYTE_ARRAY[X, Y] / 23.18); //Scale the value from 0 to 255 to 0 to 11.
                    switch (REDUCED_BYTE_VALUE)
                    {
                        case (0):
                            CHAR_ARRAY[X, Y] = '.'; //Lightest grayscale value.
                            break;
                        case (1):
                            CHAR_ARRAY[X, Y] = ',';
                            break;
                        case (2):
                            CHAR_ARRAY[X, Y] = '-';
                            break;
                        case (3):
                            CHAR_ARRAY[X, Y] = '~';
                            break;
                        case (4):
                            CHAR_ARRAY[X, Y] = ':';
                            break;
                        case (5):
                            CHAR_ARRAY[X, Y] = ';';
                            break;
                        case (6):
                            CHAR_ARRAY[X, Y] = '=';
                            break;
                        case (7):
                            CHAR_ARRAY[X, Y] = '!';
                            break;
                        case (8):
                            CHAR_ARRAY[X, Y] = '*';
                            break;
                        case (9):
                            CHAR_ARRAY[X, Y] = '#';
                            break;
                        case (10):
                            CHAR_ARRAY[X, Y] = '$';
                            break;
                        case (11):
                            CHAR_ARRAY[X, Y] = '@'; //Darkest grayscale value.
                            break;
                        default:
                            CHAR_ARRAY[X, Y] = 'X'; //If the array has invalid values.
                            break;
                    }
                }
            }
            return CHAR_ARRAY;
        }
    }
}