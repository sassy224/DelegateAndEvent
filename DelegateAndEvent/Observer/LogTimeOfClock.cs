using DelegateAndEvent.Event;
using DelegateAndEvent.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndEvent.Observer
{
    // A second subscriber whose job is to write to a file
    public class LogTimeOfClock
    {
        public void Subscribe(Clock theClock)
        {
            Console.WriteLine("LogTimeOfClock will now observer Clock for its event SecondChangeEvent");
            theClock.SecondChangeEvent += new Clock.SecondChangeHandler(WriteLogEntry);
        }

        public void Unsubscribe(Clock theClock)
        {
            Console.WriteLine("LogTimeOfClock will now stop observing Clock for its event SecondChangeEvent");
            theClock.SecondChangeEvent -= new Clock.SecondChangeHandler(WriteLogEntry);
        }

        // This method should write to a file
        // we write to the console to see the effect
        // this object keeps no state
        public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
        {
            Console.WriteLine("Subscriber DisplayTimeOfClock, received notify from Clock that second changed, log to console: {0}:{1}:{2}",
                               ti.hour.ToString(),
                               ti.minute.ToString(),
                               ti.second.ToString());
        }
    }
}
