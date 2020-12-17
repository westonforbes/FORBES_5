using System;

namespace FORBES_5.STOPWATCH_NAMESPACE
{
    /// <summary>
    /// This class is a simple stopwatch class that does not use background resources (no timer thread). It simply calculates the time difference
    /// between start and stop using the system clock. Note that this may not be suitable for some applications because events such as daylight savings time
    /// will cause miscalcluations. This if for lightweight, non-critical applications.
    /// </summary>
    public class STOPWATCH
    {
        /// <summary>
        /// This class will automatically timestamp on initialization, so using the START/MARK/RESTART methods are not required.
        /// </summary>
        public STOPWATCH() {START_TIME = DateTime.Now;}
        /// <summary>
        /// The start timestamp.
        /// </summary>
        public DateTime START_TIME { get; private set; }
        /// <summary>
        /// The stop timestamp.
        /// </summary>
        public DateTime STOP_TIME { get; private set; } = new DateTime();
        /// <summary>
        /// The time difference between STOP_TIME and START_TIME. Method MARK_STOP_TIME must be called to perform calculation. 
        /// Note that MARK_STOP_TIME will  automatically return this property.
        /// </summary>
        public TimeSpan ELAPSED_TIME { get; private set; } = new TimeSpan();
        /// <summary>
        /// Marks the start time.
        /// </summary>
        public void MARK_START_TIME() 
        { 
            START_TIME = DateTime.Now; 
        }
        /// <summary>
        /// Marks the stop time and returns the automatically returns the property ELAPSED_TIME.
        /// </summary>
        /// <returns>the TimeSpan property ELAPSED_TIME.</returns>
        public TimeSpan MARK_STOP_TIME()
        {
            STOP_TIME = DateTime.Now;
            ELAPSED_TIME = STOP_TIME - START_TIME;
            return ELAPSED_TIME;
        }
    }
}
