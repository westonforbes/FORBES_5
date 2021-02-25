using System;
using System.Collections.Generic;
using FORBES_5.MY_MATH_NAMESPACE;

namespace MY_MATH_TEST_APPLICATION
{
    class Program
    {
        static void Main(string[] args)
        {
            //Indicate program start.
            Console.WriteLine("Welcome");

            //Create a list of points.
            var POINT_LIST = new List<DOUBLE_POINT>(); 

            //Add some points.
            POINT_LIST.Add(new DOUBLE_POINT(2, 3));
            POINT_LIST.Add(new DOUBLE_POINT(3, 4));
            POINT_LIST.Add(new DOUBLE_POINT(7, 5));
            POINT_LIST.Add(new DOUBLE_POINT(7, 9));

            //Calculate the linear equation using the least squares method.
            double[] M_B = MY_MATH.LINEAR_REGRESSION(POINT_LIST);
            
            //Unpack M & B from the returned array.
            double M = M_B[0];
            double B = M_B[1];

            //Calculate Y.
            double X = 10;
            double Y = MY_MATH.LINEAR_EQUATION(M, X, B);

            //Print to console.
            Console.WriteLine("{0} = {1}*{2} + {3}", Y, M, X, B);

            Console.ReadLine();
        }
    }
}
