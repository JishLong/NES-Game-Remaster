Josh Long - 10/22/22, Sprint 3 - Room.cs - written by Hayden Gray

This class contains everything within a given room - the enemies, blocks, items, etc. The class is somewhat long, which can oftentimes make it harder to maintain, but most of the lines of code are simply dealing with handling the lists of game objects within the room. In fact, the majority of this class's functionality can be boiled down to maintaining a few lists of game objects and updating/drawing each object in the lists - this is a function which is easy to maintain.

There are, however, a few extra things the room class knows about, such as the rooms next to it as well as the level itself. This introduces some amount of coupling, though I'm not certain it's a massive issue since this information is used sparingly.

Overall, this class seems to have a high level of maintainability, and is quite easy to read through as well.
