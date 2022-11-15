Josh Long - 11/13/22, Sprint 4 - EventMaster.cs - written by Hayden Gray - time taken to write: 7 minutes

The first thing I notice with a peek into this class is that it seems to operate at quite a high level of abstraction. Firstly, this class does a great job of programming to an interface, with the only fields being of type IEvent. Secondly, this class has functionality that takes into account the flexibility of what exactly an event may be and only calls on the one method from the IEvent interface. Additionally, this class is quite short and seems to have very high cohesion - it simply deals with updating a collection of events - namely the events loaded in for a specific level - and nothing more.

All in all, I'd say the maintainability for this particular class looks very good.
