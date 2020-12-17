using System;
using FORBES_5.STOPWATCH_NAMESPACE;

namespace STOPWATCH_TEST_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
            var STOPWATCH_1 = new STOPWATCH(); //Start a STOPWATCH.
            System.Threading.Thread.Sleep(100); //Do stuff...
            Console.WriteLine("Total Time: {0}", STOPWATCH_1.MARK_STOP_TIME().TotalMilliseconds); //Print results.
        }
    }
}
