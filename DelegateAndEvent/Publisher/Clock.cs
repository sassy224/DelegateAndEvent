using DelegateAndEvent.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateAndEvent.Publisher
{
    /* ======================= Event Publisher =============================== */

    // Our subject -- it is this class that other classes will observe. 
    // This class publishes one event: SecondChange. 
    // The observers subscribe to that event.
    public class Clock
    {
        // Private Fields holding the hour, minute and second
        private int _hour = System.DateTime.Now.Hour;
        private int _minute = System.DateTime.Now.Minute;
        private int _second = System.DateTime.Now.Second;

        // The delegate named SecondChangeHandler, which will encapsulate
        // any method that takes a clock object and a TimeInfoEventArgs
        // object as the parameter and returns no value. It's the
        // delegate the subscribers must implement.
        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);

        // The event we publish
        public event SecondChangeHandler SecondChangeEvent;

        // The method which fires the Event
        protected void OnSecondChange(object clock, TimeInfoEventArgs timeInformation)
        {
            //Do something first
            Console.WriteLine("Time from clock: {0}:{1}:{2}",
                               _hour.ToString(),
                               _minute.ToString(),
                               _second.ToString());
            Console.WriteLine("Time changed, subscribers will be notified.");

            // Check if there are any Subscribers, if there are, notify them through SecondChangeEvent 
            if (SecondChangeEvent != null)
            {
                // Call the Event
                SecondChangeEvent(clock, timeInformation);
            }
        }

        // Set the clock running, it will raise an
        // event for each new second
        public void Run(int seconds)
        {
            for (int i=0; i<= seconds; i++)
            {
                // Sleep 1 Second
                Thread.Sleep(1000);

                // Get the current time
                System.DateTime dt = System.DateTime.Now;

                // If the second has changed
                // notify the subscribers
                if (dt.Second != _second)
                {
                    // Create the TimeInfoEventArgs object
                    // to pass to the subscribers
                    TimeInfoEventArgs timeInformation =
                       new TimeInfoEventArgs(
                       dt.Hour, dt.Minute, dt.Second);

                    // If anyone has subscribed, notify them
                    OnSecondChange(this, timeInformation);
                }

                // update the state
                _second = dt.Second;
                _minute = dt.Minute;
                _hour = dt.Hour;
            }
        }
    }
}
