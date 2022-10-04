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


- ##Player
- ----- Utilized state pattern, simple one line state methods for each possible action or state of player and a controller class set that implements all method headers. 
- -----Sprites categories for handling stationary player state, walking direction and attacking directions. 
- -----Command Pattern for input, movement and damage execution.
- ##Blocks
- -----Command pattern for block type swapping
- -----Factory, block switch case for all block types.
- -----Abstract block class, all various blocks extend functionality... seperate classes to load each block sprite.
- ##Bosses
- -----abstract class for common damage logic.
- -----individual boss classes for individual behaviors and movements.
- ##Items
- -----Command pattern for item type swapping
- -----Factory, item switch case for all item types.
- -----Abstract item class, all various item extend functionality... seperate classes to load each item sprite.
- ##Input
- -----Action map relating keystates by 4 key enums, HELD,UP,PRESSED,RELEASED.
- -----Current keystate distinctation logic.
- ##Enemies
- -----Weapon+non-weapon weilding enemy interface implimentation.
- -----Seperate enemy classes to distinguish unique movements and sprites
- -----Behaviors for Attacks(Kills+Stuns) and Various movements(Omnidirectional,Orthogonal,Square).

Finally, here are the various ways in which the development of this project has been documented:

- Task tracking (on GitHub) - below is a link to a GitHub page which contains all the tasks that the team was assigned for Sprint 2. In the case this link is faulty or requires a login to GitHub, etc., a picture has been placed in the Documentation folder as an alternative viewing method.

https://github.com/orgs/Code-Commanders/projects/2/views/4

- Code metrics analysis - the code metrics for the final state of the Sprint 2 solution was calculated using Visual Studio's analyze menu. A picture of the results can be found in the Documentation folder.

- Code reviews - various code reviews with focuses on code readability and maintainability can be found in the Code Reviews folder.

- Final reflection - a small discussion on the team's overall performance, including notable strengths and weaknesses, can be found in the Reflections folder. In this report, the team discusses the developmental process for this project, considers what worked versus what didn't, and gives thoughts on development for future sprints.
