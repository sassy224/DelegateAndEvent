# DelegateAndEvent
C# example about how to use Delegate and Event.

#Program1.cs
Example about how to use delegate.

#Program2.cs
Example about how to use delegate and event. 
- Create a class **Clock** that will publish event **SecondChangeHandler** every time its second changes.
- Create two other classes: **DisplayTimeOfClock** and **LogTimeOfClock** that subscribe to event **SecondChangeHandler** of **Clock**. 
- Every time the clock' second changes, it will notify its observers/subscribers (here are **DisplayTimeOfClock** and **LogTimeOfClock**) about the change and let them do what they want with that information
