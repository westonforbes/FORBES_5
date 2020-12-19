using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Data;
using FORBES_5.EXTENSIONS_NAMESPACE;

namespace FORBES_5.LOGGER_NAMESPACE
{
    /// <summary>
    /// This class handles all the logging needs of a small application.
    /// </summary>
    public static class LOGGER
    {
        //Objects---------------------------------------------------------------------------------------------------------------------
        const int NUMBER_OF_LOG_FILES_TO_RETAIN = 5; //Change this and recompile to vary how many log records are retained.
                                                       //This class will automatically delete old log files.
        private static int ENTRY_ID = 0; //Holds how many entries are in the log. Used for entry ID purposes and overflow protection.
        static int INDENT_LEVEL  = 0; //This is how many indents each message should be. Its done this way rather than using the
                                      //indent feature of Trace because the first part of the message we dont want to indent at all.
        /// <summary>
        /// The location of the currently used log file.
        /// </summary>
        public static string LOG_FILE_LOCATION;
        //----------------------------------------------------------------------------------------------------------------------------
        
        /// <summary>
        /// Class contructor.
        /// </summary>
        static LOGGER()
        {
            LOG_FILE_LOCATION = CONSTRUCT_LOG_FILE_NAME();
            bool LOGS_DIRECTORY_EXISTS = Directory.Exists(Directory.GetCurrentDirectory() + "\\LOGS\\"); //Check if the logs directory exists.
            if (!LOGS_DIRECTORY_EXISTS) //If the directory does not exist...
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\LOGS\\"); //Create the directory.
            Trace.Listeners.Add(new TextWriterTraceListener(LOG_FILE_LOCATION, "Log File")); //Add a listener which will log all the data.
            Trace.AutoFlush = true; //Automatically flush the trace buffer.
            Trace.WriteLine("      Timestamp     | Code | Entry ID |    Method Name                   | Message"); //Print a header to the log file.
            METHOD_ENTER(); //This isn't the beginning of the constructor but we're gonna make the call for visual uniformity.
            LOG( "*** Log created.", 910); //Create the first message.
            ERASE_OLD_LOGS(); //Check if there are any old log files that need to be deleted.
            METHOD_EXIT();
        }
        
        /// <summary>
        /// This method will inspect the LOGS folder and erase any old log files.
        /// </summary>
        private static void ERASE_OLD_LOGS()
        {
            METHOD_ENTER();
            try
            {
                var DIR = Directory.GetCurrentDirectory() + "\\LOGS\\";
                LOG( "Checking for old log files.", 910);
                foreach (var FILE in new DirectoryInfo(DIR).GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(NUMBER_OF_LOG_FILES_TO_RETAIN))
                //Go through each file in the directory, skip the newest 5.
                {
                    LOG(string.Format("Checking file: {0}", Path.GetFileName(FILE.ToString())), 910);
                    if (FILE.Name.Contains("LOG_FILE_")) //If its a log file...
                    {
                        LOG(string.Format("Deleting file: {0}", Path.GetFileName(FILE.ToString())), 910);
                        FILE.Delete(); //Delete the file.
                    }
                }
            }
            catch (Exception) { Console.WriteLine(""); }
            METHOD_EXIT();
        }
        
        /// <summary>
        /// This method creates the name of the log.
        /// </summary>
        /// <returns>The name of the log (full path).</returns>
        private static string CONSTRUCT_LOG_FILE_NAME()
        {
            var TIME = DateTime.Now;
            string STRING = Directory.GetCurrentDirectory() + "\\LOGS\\" + "LOG_FILE_" +
                            TIME.Year.ToString("0000") + "_" +
                            TIME.Month.ToString("00") + "_" +
                            TIME.Day.ToString("00") + "_" +
                            TIME.Hour.ToString("00") + "_" +
                            TIME.Minute.ToString("00") + "_" +
                            TIME.Second.ToString("00") + ".log";
            return STRING;
        }

        /// <summary>
        /// This method will log a entry to the log.
        /// </summary>
        /// <param name="GROUP">
        /// <para>Code on how to file the entry.</para>
        /// <para>The programmer can decide how to lay this out. Any values between and including 1 and 999 are accepted.</para>
        /// <para>This class uses codes in the 900 range for reserved messages.</para>
        /// <para>Invalid codes will default to zero.</para>
        /// </param>
        /// <param name="MESSAGE">The message you wish to write to the log.</param>
        /// <param name="STACK_TRACE_FRAME">This defaults to 2. Which will show the method that called this method.</param>
        public static void LOG(string MESSAGE, int GROUP = 0, int STACK_TRACE_FRAME = 2)
        {
            //Setup all the needed data...
            string CALLING_METHOD = GET_CALLING_METHOD(STACK_TRACE_FRAME); //Get the calling method.
            DateTime TIME_STAMP = DateTime.Now; //Get the time.
            if (GROUP > 999 || GROUP < 1) //Make sure group is valid...
                GROUP = 0; //If its not, zero it out.
            

            //Check if this is a special blank case. This was added because the programmer may just want a blank line
            //written to the output for readability. This will do it and return out of the method.
            if(MESSAGE == null) //If a null value was sent in the message...
            {
                Trace.WriteLine(""); //Write a blank console line.
                return; //Exit out of the function.
            }
            
            //Construct the output message.
            string OUTPUT_MESSAGE;
            OUTPUT_MESSAGE = TIME_STAMP.ToString("s") + " | "; //Construct the output message.
            OUTPUT_MESSAGE += GROUP.ToString("0000") + " | "; //Construct the output message.
            OUTPUT_MESSAGE += ENTRY_ID.ToString("00000000") + " | "; //Construct the output message.
            OUTPUT_MESSAGE += CALLING_METHOD.TRUNCATE_AND_PAD(32) + " | ";
            string PAD = "";
            for(int i = 0; i < INDENT_LEVEL; i++)
            {
                PAD += "    ";
            }
            OUTPUT_MESSAGE += PAD + MESSAGE; //Construct the output message.
            Trace.WriteLine(OUTPUT_MESSAGE);
            ENTRY_ID += 1;
        }
        
        /// <summary>
        /// Call this method on entering a new method you wish to track. Be sure to include one of the EXIT methods too, otherwise indentation will be off.
        /// </summary>
        public static void METHOD_ENTER()
        {
            LOG( ">>> Thread entering method.", 900, 3); //Call the LOG method with the reserved word. Modify the stack trace frame up a extra level.
            INDENT_LEVEL += 1;
        }

        /// <summary>
        /// Call this method on exiting a method you wish to track. Be sure to include METHOD_ENTER at the beginning of the method.
        /// </summary>
        public static void METHOD_EXIT()
        {
            if (INDENT_LEVEL > 0)
                INDENT_LEVEL -= 1;
            LOG( "<<< Thread exiting method.", 901, 3); //Call the LOG method with the reserved word. Modify the stack trace frame up a extra level.

        }
        
        /// <summary>
        /// Call this method on exiting a method you wish to track. Be sure to include METHOD_ENTER at the beginning of the method.
        /// </summary>
        public static void METHOD_EXIT_FAIL()
        {
            if (INDENT_LEVEL > 0)
                INDENT_LEVEL -= 1;
            LOG( "<<< Thread exiting method. FAILED.", 902, 3); //Call the LOG method with the reserved word. Modify the stack trace frame up a extra level.
        }
        
        /// <summary>
        /// Call this method on exiting a method you wish to track. Be sure to include METHOD_ENTER at the beginning of the method.
        /// </summary>
        public static void METHOD_EXIT_SUCCESS()
        {
            if (INDENT_LEVEL > 0)
                INDENT_LEVEL -= 1;
            LOG( "<<< Thread exiting method. SUCCESS.", 903, 3); //Call the LOG method with the reserved word. Modify the stack trace frame up a extra level.
        }
        
        /// <summary>
        /// Call this method when an exception is thrown. Pass the exception message along as well.
        /// </summary>
        /// <param name="EX_MESSAGE">The exception message.</param>
        public static void EXCEPTION(string EX_MESSAGE) 
        {
            LOG(string.Format("XXX Exception: {0}", EX_MESSAGE), 904, 3); //Call the LOG method with the reserved word. Modify the stack trace frame up a extra level.
        }

        /// <summary>
        /// This method will attempt to open the log file in the default viewer.
        /// </summary>
        /// <returns></returns>
        public static int OPEN_LOG()
        {
            METHOD_ENTER();
            try
            {
                Process.Start(new ProcessStartInfo() { FileName = LOGGER.LOG_FILE_LOCATION, UseShellExecute = true, Verb = "open" });
                LOG("Opened log file.", 912, 1);
            }
            catch(Exception EX)
            {
                EXCEPTION(EX.Message);
                METHOD_EXIT_FAIL();
                return -1;
            }
            METHOD_EXIT_SUCCESS();
            return 0;         
        }
        
        /// <summary>
        /// This method will return the calling method. It defaults to 2 because most 
        /// of the time we only care about whos calling from outside this class,
        /// so we have to go past the actual calling frame up an extra level to 2.
        /// </summary>
        /// <param name="FRAME_LEVEL">The frame level to inspect.</param>
        /// <returns>The name of the method.</returns>
        private static string GET_CALLING_METHOD(int FRAME_LEVEL = 2)
        {
            string CALLING_METHOD;
            try //Seeing as we're dealing with stack traces, probably a good idea to get ready to catch problems. 
                //Also, it'll clean itself up afterwards, so bonus.
            {
                if (FRAME_LEVEL < 1) //If the passed stack level is less than 1...
                    return null; //Return out, values less than one are invalid.
                StackTrace STACK_TRACE = new StackTrace(); //Get the calling stack.
                CALLING_METHOD = STACK_TRACE.GetFrame(FRAME_LEVEL).GetMethod().Name;//Get calling method name.
            }
            catch (Exception) { return null; } //Catch any problems and return out with nothing.
            switch(CALLING_METHOD)
            {
                case (".ctor"):
                    CALLING_METHOD = "CONSTRUCTOR";
                        break;
                case (".cctor"):
                    CALLING_METHOD = "STATIC CONSTRUCTOR";
                    break;

            }
            return CALLING_METHOD; //Return the method name.
        }
    }

}



