# CSE-3902-Project - Sprint 2

This README file contains brief instructions/information regarding this project as well as its documentative efforts.

Firstly, here is a quick and explicit review of the game controls:

- Arrows, WASD: movement of Link
- Z, N: sword attack
- E: become damaged

- T, Y: cycle between items
- U, I: cycle between blocks
- O, P: cycle between enemies, bosses, and NPCs

- R: reset the game
- Q: quit the game

As of writing this document, no known bugs have been found during playtesting. However, seeing as this is a work-in-progress, this does not guarantee the absence of bugs.


##Player
----Utilized state pattern, simple one line state methods for each possible action or state of player and a controller class set that implements all method headers. 
----Sprites categories for handling stationary player state, walking direction and attacking directions. 
----Command Pattern for input, movement and damage execution.
##Blocks
----Command pattern for block type swapping
----Factory, block switch case for all block types.
----Abstract block class, all various blocks extend functionality... seperate classes to load each block sprite.
##Bosses
-----abstract class for common damage logic.
-----individual boss classes for individual behaviors and movements.
##Items
----Command pattern for item type swapping
----Factory, item switch case for all item types.
----Abstract item class, all various item extend functionality... seperate classes to load each item sprite.
##Input
-----Action map relating keystates by 4 key enums, HELD,UP,PRESSED,RELEASED.
-----Current keystate distinctation logic.
##Enemies
-----Weapon+non-weapon weilding enemy interface implimentation.
-----Seperate enemy classes to distinguish unique movements and sprites
-----Behaviors for Attacks(Kills+Stuns) and Various movements(Omnidirectional,Orthogonal,Square).
