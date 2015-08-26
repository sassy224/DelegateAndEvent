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
    // Program which implements a simple example of delegate
    // There are three steps in defining and using delegates:
    // - Declaration
    // - Instantiation
    // - Invocation
    public class Program1
    {
        // Declaration
        // A delegate type with signature: 1 single param of type text and return void
        public delegate void DelegateHandler(string text);

        public static void Foo(string text)
        {
            Console.WriteLine(String.Format("Foo is invoked. Param is \"{0}\"", text));
        }
        
        public static void Main()
        {
            // Instantiation
            // Delegate is a class, so you instantiate it by using new keyword
            DelegateHandler handler = new DelegateHandler(Foo);

            // Invocation
            Console.WriteLine("Foo will be invoked by delegate");
            handler("called from delegate");

            Console.WriteLine("Foo will be invoked directly");
            Foo("called directly");
        }
    }
}
