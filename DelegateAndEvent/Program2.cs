//Based on the awesome article here: http://www.akadia.com/services/dotnet_delegates_and_events.html
using DelegateAndEvent.Observer;
using DelegateAndEvent.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateAndEvent
{
    // Program which implements the
    // Clock Notifier - Subscriber Sample
    public class Program2
    {
        public static void Main()
        {
            // Create a new clock - the publisher, which will publish the SecondChangeEvent 
            Clock theClock = new Clock();

            // Create the display and tell it to
            // subscribe to the clock just created
            DisplayTimeOfClock dc = new DisplayTimeOfClock();
            dc.Subscribe(theClock);

            // Create a Log object and tell it
            // to subscribe to the clock
            LogTimeOfClock lc = new LogTimeOfClock();
            lc.Subscribe(theClock);

            //Write separator for clearer console
            Console.WriteLine("=====");

            // Get the clock started, let it run for 10 secs
            theClock.Run(1);

            //Stop DisplayTimeOfClock from observer the Clock
            dc.Unsubscribe(theClock);

            //Write separator for clearer console
            Console.WriteLine("=====");

            //Let the clock run for another 5 secs
            theClock.Run(1);
        }
    }
}
