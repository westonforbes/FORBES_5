using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORBES_5.MY_MATH_NAMESPACE
{
    /// <summary>
    /// A point class for doubles. Contains X, Y and Z coordinates.
    /// </summary>
    public class DOUBLE_POINT
    {
        /// <summary>
        /// Undefined initialization.
        /// </summary>
        public DOUBLE_POINT()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        /// <summary>
        /// Two dimensional initialization.
        /// </summary>
        /// <param name="X">The X value.</param>
        /// <param name="Y">The Y value.</param>
        public DOUBLE_POINT(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
            this.Z = 0;
        }

        /// <summary>
        /// Three dimensional initialization.
        /// </summary>
        /// <param name="X">The X value.</param>
        /// <param name="Y">The Y value.</param>
        /// <param name="Z">The Z value.</param>
        public DOUBLE_POINT(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
       
        /// <summary>
        /// The X value.
        /// </summary>
        public double X { get; set; }
       
        /// <summary>
        /// The Y value.
        /// </summary>
        public double Y { get; set; }
       
        /// <summary>
        /// The Z value.
        /// </summary>
        public double Z { get; set; }
    }

    /// <summary>
    /// A class for containing vector information for an object.
    /// </summary>
    public class VECTOR
    {
        /// <summary>
        /// A class for containing vector information for an object. Uninitialized members will default to zero.
        /// </summary>
        public VECTOR()
        {
            this.POINT_DATA = new DOUBLE_POINT();
            this.SPEED = 0;
            this.ANGLE_DEG = 0;
            this.ACCELERATION = 0;
            this.DECELERATION = 0;
        }

        /// <summary>
        /// A class for containing vector information for an object. Uninitialized members will default to zero.
        /// </summary>
        /// <param name="POINT_DATA"> The point data of the object.</param>
        public VECTOR(DOUBLE_POINT POINT_DATA)
        {
            this.POINT_DATA = POINT_DATA;
            this.SPEED = 0;
            this.ANGLE_DEG = 0;
            this.ACCELERATION = 0;
            this.DECELERATION = 0;
        }
        
        /// <summary>
        /// A class for containing vector information for an object. Uninitialized members will default to zero.
        /// </summary>
        /// <param name="POINT_DATA"> The point data of the object.</param>
        /// <param name="SPEED">The speed of the object.</param>
        public VECTOR(DOUBLE_POINT POINT_DATA, double SPEED)
        {
            this.POINT_DATA = POINT_DATA;
            this.SPEED = SPEED;
            this.ANGLE_DEG = 0;
            this.ACCELERATION = 0;
            this.DECELERATION = 0;
        }

        /// <summary>
        /// A class for containing vector information for an object. Uninitialized members will default to zero.
        /// </summary>
        /// <param name="POINT_DATA"> The point data of the object.</param>
        /// <param name="SPEED">The speed of the object.</param>
        /// <param name="ANGLE_DEG">The heading of the object.</param>
        public VECTOR(DOUBLE_POINT POINT_DATA, double SPEED, double ANGLE_DEG)
        {
            this.POINT_DATA = POINT_DATA;
            this.SPEED = SPEED;
            this.ANGLE_DEG = ANGLE_DEG;
            this.ACCELERATION = 0;
            this.DECELERATION = 0;
        }

        /// <summary>
        /// A class for containing vector information for an object. Uninitialized members will default to zero.
        /// </summary>
        /// <param name="POINT_DATA"> The point data of the object.</param>
        /// <param name="SPEED">The speed of the object.</param>
        /// <param name="ANGLE_DEG">The heading of the object.</param>
        /// <param name="ACCELERATION">The acceleration of the object.</param>
        public VECTOR(DOUBLE_POINT POINT_DATA, double SPEED, double ANGLE_DEG, double ACCELERATION)
        {
            this.POINT_DATA = POINT_DATA;
            this.SPEED = SPEED;
            this.ANGLE_DEG = ANGLE_DEG;
            this.ACCELERATION = ACCELERATION;
            this.DECELERATION = 0;
        }

        /// <summary>
        /// A class for containing vector information for an object. Uninitialized members will default to zero.
        /// </summary>
        /// <param name="POINT_DATA"> The point data of the object.</param>
        /// <param name="SPEED">The speed of the object.</param>
        /// <param name="ANGLE_DEG">The heading of the object.</param>
        /// <param name="ACCELERATION">The acceleration of the object.</param>
        /// <param name="DECELERATION">The deceleration of the object.</param>
        public VECTOR(DOUBLE_POINT POINT_DATA, double SPEED, double ANGLE_DEG, double ACCELERATION, double DECELERATION)
        {
            this.POINT_DATA = POINT_DATA;
            this.SPEED = SPEED;
            this.ANGLE_DEG = ANGLE_DEG;
            this.ACCELERATION = ACCELERATION;
            this.DECELERATION = DECELERATION;
        }

        public DOUBLE_POINT POINT_DATA;
        public double SPEED;
        public double ANGLE_DEG;
        public double ACCELERATION;
        public double DECELERATION;
    }

    /// <summary>
    /// This class holds math functions I find useful, or just math functions that I thought would be fun to write.
    /// </summary>
    public static class MY_MATH
    {
        /// <summary>
        /// Just a simple method for Y = MX+B.
        /// </summary>
        /// <param name="M">Multiplier</param>
        /// <param name="X">Value</param>
        /// <param name="B">Offset</param>
        /// <returns>Y</returns>
        public static double LINEAR_EQUATION(double M, double X, double B) { return M * X + B; }

        /// <summary>
        /// Calculates the 2D linear equation from a list of points using the least squares method.
        /// </summary>
        /// <param name="POINT_LIST">The list of points to calculate the equation from.</param>
        /// <returns>An array with position 0 equaling M and position 1 equaling B.</returns>
        public static double[] LINEAR_REGRESSION(List<DOUBLE_POINT> POINT_LIST)
        {
            //Declare variables.
            double MEAN_X = new double();
            double MEAN_Y = new double();
            double MEAN_XY = new double();
            double MEAN_X_SQUARE = new double();
            int COUNT = POINT_LIST.Count;
            
            //Sum up values.
            foreach (DOUBLE_POINT POINT in POINT_LIST) 
            {
                MEAN_X += POINT.X;
                MEAN_Y += POINT.Y;
                MEAN_XY += (POINT.X * POINT.Y);
                MEAN_X_SQUARE += (POINT.X * POINT.X);
            }
            
            //Divide sums by count to get the means.
            MEAN_X /= COUNT;
            MEAN_Y /= COUNT;
            MEAN_XY /= COUNT;
            MEAN_X_SQUARE /= COUNT;

            //Calculate M
            double M_NUMERATOR = MEAN_XY - MEAN_X * MEAN_Y;
            double M_DENOMINATOR = MEAN_X_SQUARE - MEAN_X * MEAN_X;
            double M = M_NUMERATOR / M_DENOMINATOR;

            //Calculate B
            double B = MEAN_Y - M * MEAN_X;

            return new double[] { M, B };
        }

        /// <summary>
        /// This method updates the position of a object given a specific amount of time since last update.
        /// </summary>
        /// <param name="ARG_VECTOR">The vector information of the object.</param>
        /// <param name="TIME_ELAPSED">The amount of elapsed time.</param>
        public static void UPDATE_VECTOR(ref VECTOR ARG_VECTOR, double TIME_ELAPSED)
        {
            double ANGLE_RAD = ARG_VECTOR.ANGLE_DEG * (Math.PI / 180);
            ARG_VECTOR.POINT_DATA.X += (ARG_VECTOR.SPEED * TIME_ELAPSED * Math.Cos(ANGLE_RAD));
            ARG_VECTOR.POINT_DATA.Y += (ARG_VECTOR.SPEED * TIME_ELAPSED * Math.Sin(ANGLE_RAD));
        }

        /// <summary>
        /// Returns a random double value that is greater than or equal to LOWER_LIM and less than UPPER_LIM.
        /// </summary>
        /// <param name="LOWER_LIM">Lower limit (greater than or equal to).</param>
        /// <param name="UPPER_LIM">Upper limit (less than but not equal to).</param>
        /// <returns>A random double variable.</returns>
        public static double RANDOM_DOUBLE(double LOWER_LIM, double UPPER_LIM)
        {
            Random RAND = new Random();
            return RAND.NextDouble() * (UPPER_LIM - LOWER_LIM) + LOWER_LIM;
        }
    }
}
