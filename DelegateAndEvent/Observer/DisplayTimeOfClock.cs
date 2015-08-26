using DelegateAndEvent.Event;
using DelegateAndEvent.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEvent.Observer
{
    /* ======================= Event Subscribers =============================== */

    // An observer. DisplayTimeOfClock subscribes to the
    // clock's events. The job of DisplayClock is
    // to display the current time
    public class DisplayTimeOfClock
    {
        // Given a clock, subscribe to
        // its SecondChangeHandler event
        public void Subscribe(Clock theClock)
        {
            Console.WriteLine("DisplayTimeOfClock will now observe Clock for its event SecondChangeEvent");
            theClock.SecondChangeEvent += new Clock.SecondChangeHandler(WriteTimeToConsole);
        }

        public void Unsubscribe(Clock theClock)
        {
            Console.WriteLine("DisplayTimeOfClock will now stop observing Clock for its event SecondChangeEvent");
            theClock.SecondChangeEvent -= new Clock.SecondChangeHandler(WriteTimeToConsole);
        }

        // The method that implements the
        // delegated functionality
        public void WriteTimeToConsole(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Subscriber DisplayTimeOfClock, received notify from Clock that second changed, display current Time: {0}:{1}:{2}",
                               ti.hour.ToString(),
                               ti.minute.ToString(),
                               ti.second.ToString());
        }
    }
}
