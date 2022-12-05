Josh Long - 10/3/22, Sprint 2 - 
Bat.cs - written by Hayden Gray

This class appears to inherit from a parent AbstractEnemy, which definitely promotes code reusability. One thing I'm not so sure on is the Destroy() method throwing an exception - this could cause some problems in the code which could be fixed just by leaving the method blank. However, this is most likely not at all a big issue. 

Interestingly, this class appears to make use of the strategy design pattern - I see that much of the logic in Update() is encapsulated within a MovementBehavior object. Suppose we wanted to make the bat home in on the player instead of moving around randomly? This change would be incredibly easy with the current code for the Bat, as you could just swap in a different behavior. This is excellent for maintainability.
